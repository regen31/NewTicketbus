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





        [HttpPost]
        public ActionResult GetScheme(int RouteId, DateTime date)
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

                    StartPoint = order.StartPoint,
                    FinalPoint = order.FinalPoint,
                    BuyDay = order.BuyDay,
                });
            }
            return PartialView(TicketsList);
        }
    }
}