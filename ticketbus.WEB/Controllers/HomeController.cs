using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticketbus.Logic.Interfaces;
using ticketbus.Logic.DTO;
using ticketbus.WEB.Models;


namespace ticketbus.WEB.Controllers
{
    public class HomeController : Controller
    {
        IRouteService RouteRepository;
        INewsService NewsRepository;
        public HomeController(IRouteService routerepository, INewsService newsrepository)
        {
            RouteRepository = routerepository;
            NewsRepository = newsrepository;
        }

        public ActionResult Index()                 
        {
            
            return View(new RouteViewModel());
        }

       
        [HttpPost]
        public ActionResult ShowTable(RouteViewModel route)
        {
            List<RouteViewModel> ViewList = new List<RouteViewModel>();

            var FindedRoutes = RouteRepository.GetFindedRoutes(route.StartPoint, route.FinalPoint, route.DateForSearch);

            foreach (var FindedRoute in FindedRoutes)
            {
                ViewList.Add(new RouteViewModel() { StartPoint = FindedRoute.StartPoint, FinalPoint = FindedRoute.FinalPoint, DepartureTime = FindedRoute.DepartureTime, ArrivalTime = FindedRoute.ArrivalTime });
            }
            return PartialView("ShowTable", ViewList);
        }


        public PartialViewResult ShowNews()
        {
            List<NewsViewModel> NewsList = new List<NewsViewModel>();
            var News = NewsRepository.GetSomeDTO();
            foreach(var item in News)
            {
                NewsList.Add(new NewsViewModel() {
                    Date = item.Date,
                    Text = item.Text,
                });
            }
            return PartialView(NewsList);
        }
    }
}