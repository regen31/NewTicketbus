﻿using System;
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

        public OrderController(IUserService userrepo, IRouteService routerepo)
        {
            UserService = userrepo;
            RouteService = routerepo;
        }





        [HttpPost]
        public ActionResult BuyTicket(int RouteId, DateTime date)
        {
            var route = RouteService.GetRoute(RouteId);
                                    
            BoughtTicketDTO ticket = new BoughtTicketDTO {
                RouteId = route.Id,
                Buyer = User.Identity.Name,
                StartPoint = route.StartPoint,
                FinalPoint = route.FinalPoint,
                BuyDay = date,
            };

            UserService.AddBoughtTicket(ticket);
            
            return PartialView();
        }
    }
}