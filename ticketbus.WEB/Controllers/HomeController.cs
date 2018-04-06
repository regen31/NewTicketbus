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
    public class HomeController : Controller
    {
        IRouteService RouteRepository;
        INewsService NewsRepository;
        IUserService UserRepository;
        public HomeController(IRouteService routerepository, INewsService newsrepository, IUserService userrepository)
        {
            RouteRepository = routerepository;
            NewsRepository = newsrepository;
            UserRepository = userrepository;
        }

        public ActionResult Index()                 
        {

            return View();
        }

        [HttpPost]
        public ActionResult LoginForm(UserViewModel usermodel)
        {

            if (ModelState.IsValid)
                FormsAuthentication.SetAuthCookie(usermodel.Name, true);

            return View();
        }


        [HttpPost]
        public ActionResult ShowTable(RouteViewModel route)
        {
            List<RouteViewModel> ViewList = new List<RouteViewModel>();

            var FindedRoutes = RouteRepository.GetFindedRoutes(route.StartPoint, route.FinalPoint, route.DateForSearch);

            foreach (var FindedRoute in FindedRoutes)
            {
                ViewList.Add(new RouteViewModel() { DateForSearch = route.DateForSearch, Id = FindedRoute.Id, StartPoint = FindedRoute.StartPoint, FinalPoint = FindedRoute.FinalPoint, DepartureTime = FindedRoute.DepartureTime, ArrivalTime = FindedRoute.ArrivalTime, Seats = FindedRoute.Seats, });
            }
            return PartialView("ShowTable", ViewList);
        }

        [ChildActionOnly]
        public ActionResult ShowNews()
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

        [ChildActionOnly]
        public ActionResult ShowAllRoutes()
        {
            List<RouteViewModel> AllRoutes = new List<RouteViewModel>();

            var allformDB = RouteRepository.GetAllRoutes();

            foreach (var route in allformDB)
            {
                AllRoutes.Add(new RouteViewModel() {StartPoint = route.StartPoint, FinalPoint = route.FinalPoint, DepartureTime = route.DepartureTime, ArrivalTime = route.ArrivalTime, Seats = route.Seats });
            }
            return PartialView(AllRoutes);
        }
    }
}