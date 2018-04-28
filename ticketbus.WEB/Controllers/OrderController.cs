using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticketbus.Logic.Interfaces;
using ticketbus.Logic.DTO;
using ticketbus.WEB.Models;
using System.Web.Security;


namespace ticketbus.WEB.Controllers
{
    public class OrderController : Controller
    {

        IUserService UserService;
        IRouteService RouteService;
        IOrderService OrderService;

        public OrderController(IUserService userrepo, IRouteService routerepo, IOrderService orderrepo)
        {
            UserService = userrepo;
            RouteService = routerepo;
            OrderService = orderrepo;
        }





        [HttpGet]
        public ActionResult GetScheme()
        {
            return PartialView();
        }


        [HttpGet]
        public ActionResult GetUsersOrders() {
            List<BoughtTicketViewModel> TicketsList = new List<BoughtTicketViewModel>();
            var orders = UserService.GetUsersOrders(User.Identity.Name).ToList();

            if (orders.Count > 0)
            {
                foreach (var order in orders)
                {
                    TicketsList.Add(new BoughtTicketViewModel()
                    {
                        RouteId = order.RouteId,
                        Buyer = order.Buyer,
                        SeatId = order.SeatId,

                        StartPoint = order.StartPoint,
                        FinalPoint = order.FinalPoint,
                        BuyDay = order.BuyDay,
                    });
                }                
            }
            return PartialView(TicketsList);

        }

        [HttpPost]
        public JsonResult GetBoughtTicketsSeatsId(int RouteId, DateTime date)
        {
            List<string> IdList = new List<string>();
            var BoughtTickets = OrderService.GetOrdersForRoute(RouteId, date);

            foreach (var ticket in BoughtTickets)
            {
                IdList.Add(ticket.SeatId.ToString());
            }
            
            return Json(IdList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ShowPaymentOptions()
        {            
            return PartialView();
        }


        [HttpPost]
        public ActionResult ShowPaymentForm(int RouteId, DateTime DepartDate, int[] ChosenSeats, string PaymentOption)
        {
            var route = RouteService.GetRoute(RouteId);

            List<BoughtTicketDTO> tickets = new List<BoughtTicketDTO>();
            for (int i = 0; i < ChosenSeats.Length; i++)
            {
                tickets.Add(new BoughtTicketDTO()
                {
                    RouteId = route.Id,
                    Buyer = User.Identity.Name,
                    SeatId = ChosenSeats[i],
                    StartPoint = route.StartPoint,     // << добавление в базу билетов со статусом Chosen
                    FinalPoint = route.FinalPoint,
                    BuyDay = DepartDate,

                    AddTime = DateTime.Now,
                    Status = "Chosen",
                });
            }
            OrderService.AddTickets(tickets);



            OrderInfoViewModel infoObject = new OrderInfoViewModel {RouteId = route.Id, StartPoint = route.StartPoint, FinalPoint = route.FinalPoint, DepartDate = DepartDate, DepartTime = route.DepartureTime, SeatsCount = ChosenSeats.Length, ChosenSeats = ChosenSeats };

            if (PaymentOption == "paymentcard")
                return PartialView("PaymentCard", new PaymentCardViewModel { OrderInfo = infoObject });
            else if (PaymentOption == "webmoney")
                return PartialView("WebMoney", new WebMoneyViewModel { OrderInfo = infoObject });
            else if (PaymentOption == "qiwi")
                return PartialView("qiwi", new QIWIViewModel { OrderInfo = infoObject });


            return HttpNotFound();
        }


        [HttpPost]
        public ActionResult PaymentCardConfirm(PaymentCardViewModel cardmodel)
        {
            OrderService.ChangeStatusChosenToBought(cardmodel.OrderInfo.RouteId, cardmodel.OrderInfo.DepartDate, cardmodel.OrderInfo.ChosenSeats);            
            return PartialView("SuccessOrder");
        }

        [HttpPost]
        public ActionResult WebMoneyConfirm(WebMoneyViewModel wmmodel)
        {
            OrderService.ChangeStatusChosenToBought(wmmodel.OrderInfo.RouteId, wmmodel.OrderInfo.DepartDate, wmmodel.OrderInfo.ChosenSeats);
            return PartialView("SuccessOrder");
        }

        [HttpPost]
        public ActionResult QiwiConfirm(QIWIViewModel model)
        {
            OrderService.ChangeStatusChosenToBought(model.OrderInfo.RouteId, model.OrderInfo.DepartDate, model.OrderInfo.ChosenSeats);
            return PartialView("SuccessOrder");
        }
    }
}