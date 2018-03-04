using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticketbus.Logic.DTO;
using ticketbus.Logic.Interfaces;

namespace ticketbus.WEB.Controllers
{
    public class AdminController : Controller
    {
        IRouteService RouteRepository;

        public AdminController(IRouteService RouteRepository)
        {
            this.RouteRepository = RouteRepository;
        }


        public ActionResult Index()
        {

            return View(RouteRepository.GetAllRoutes());
        }

       

        
        public ActionResult CreateRoute()
        {

            return View();
        }


        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateRoute(RouteDTO route)
        {
            RouteRepository.CreateRoute(route);
                return RedirectToAction("Index");
           
        }

        // GET: Admin/Edit/5
        public ActionResult EditRoute(int id)
        {
            
            return View(RouteRepository.GetRoute(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult EditRoute(RouteDTO route)
        {
            RouteRepository.Update(route);
                return RedirectToAction("Index");
        }

        // GET: Admin/Delete/5
        public ActionResult DeleteRoute(int id)
        {
            RouteRepository.DeleteRoute(id);
            return RedirectToAction("Index");
        }

        
    }
}
