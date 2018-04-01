using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticketbus.Logic.DTO;
using ticketbus.Logic.Interfaces;
using ticketbus.WEB.Models;

namespace ticketbus.WEB.Controllers
{
    
    public class AdminController : Controller
    {
        IRouteService RouteRepository;
        INewsService NewsRepository;

        public AdminController(IRouteService RouteRepository, INewsService newsrepo)
        {
            this.RouteRepository = RouteRepository;
            NewsRepository = newsrepo;
        }


        public ActionResult Index()
        {
            
            return View(RouteRepository.GetAllRoutes());

        }

         public ActionResult CreateRoute()
        {
            return View(new RouteDTO());
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

        [ChildActionOnly]
        public ActionResult ShowNews()
        {
            return PartialView(NewsRepository.GetAllDTO());            
        }

        public ActionResult DeleteNews(int id)
        {
            NewsRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult CreateNews()
        {
            return View(new NewsViewModel());
        }

        [HttpPost]
        public ActionResult CreateNews(NewsViewModel model)
        {
            NewsRepository.Create(new NewsDTO() {
                Date = model.Date,
                Text = model.Text,
            });
            return RedirectToAction("Index");
        }
    }
}
