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
            var user = UserRepository.FindUser(usermodel.Name);

            try
            {

                if (usermodel.Password != user.Password)
                    ModelState.AddModelError("Password", "Неправильный пароль");
            }

            catch
            {
                ModelState.AddModelError("Name", "Такого пользователя не существует");
            }

            if (ModelState.IsValid)
                FormsAuthentication.SetAuthCookie(user.Login, true);

            return View();

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
    }
}