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
            var orders = UserService.GetUsersOrders(User.Identity.Name);

            foreach (var order in orders)
            {
                TicketsList.Add(new BoughtTicketViewModel() {
                    RouteId = order.RouteId,
                    Buyer = order.Buyer,
                    SeatId = order.SeatId,

                    StartPoint = order.StartPoint,
                    FinalPoint = order.FinalPoint,
                    BuyDay = order.BuyDay,
                });
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

        [HttpPost]
        public ActionResult ShowPaymentOptions(int RouteId, DateTime DepartDate, int[] ChosenSeats)
        {
            var route = RouteService.GetRoute(RouteId);
            List<BoughtTicketDTO> tickets = new List<BoughtTicketDTO>();

            for(int i = 0; i < ChosenSeats.Length; i++)
            {
                tickets.Add(new BoughtTicketDTO() {
                    RouteId = route.Id,
                    Buyer = User.Identity.Name,
                    SeatId = ChosenSeats[i],
                    StartPoint = route.StartPoint,
                    FinalPoint = route.FinalPoint,
                    BuyDay = DepartDate,

                    AddTime = DateTime.Now,
                    Status = "Chosen",
                });
            }

            OrderService.AddTickets(tickets);
            return PartialView();
        }
    }
}