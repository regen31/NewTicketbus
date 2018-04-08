using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticketbus.Domain.EFContext;
using ticketbus.Domain.Entities;
using ticketbus.Domain.Interfaces;
using System.Data.Entity;



namespace ticketbus.Domain.Repositories
{
   public class RouteRepository : IRouteRepository
    {
        private BusContext db;

        public RouteRepository(string connectionString)
        {
            db = new BusContext(connectionString);
        }


        public Route GetRoute(int id)
        {
            return db.Routes.Find(id);
        }

        public IEnumerable<Route> GetAll()
        {
            return db.Routes;
        }
        
        public void UpdateRoute(Route route)
        {
            route.StartPoint = route.StartPoint.ToUpper();
            route.FinalPoint = route.FinalPoint.ToUpper();
            var RouteFromDB = db.Routes.Find(route.Id);
            if (RouteFromDB == null)
                
            {
                db.Routes.Add(route);
            }
            else
            {
                RouteFromDB.StartPoint = route.StartPoint;
                RouteFromDB.FinalPoint = route.FinalPoint;
                RouteFromDB.DepartureTime = route.DepartureTime;
                RouteFromDB.ArrivalTime = route.ArrivalTime;
                RouteFromDB.Seats = route.Seats;

                RouteFromDB.Monday = route.Monday;
                RouteFromDB.Tuesday = route.Tuesday;
                RouteFromDB.Wednesday = route.Wednesday;
                RouteFromDB.Thusday = route.Thusday;
                RouteFromDB.Friday = route.Friday;
                RouteFromDB.Saturday = route.Saturday;
                RouteFromDB.Sunday = route.Sunday;
            }
            db.SaveChanges();
        }


        public void Delete(int id)
        {
            var route = db.Routes.Find(id);
            db.Routes.Remove(route);
            db.SaveChanges();
            
        }

        //здесь какая-то жуть
        public IEnumerable<Route> FindRoutes(string start, string final, DateTime DateFromForm)  
        {
            string dateforsearch = DateFromForm.DayOfWeek.ToString();
            List<Route> RoutesToReturn = new List<Route>();
            
            //берем из базы маршруты, которые совпадают по точке отправления и точке назначения
            var routes =
                from r in db.Routes
                where r.StartPoint == start.ToUpper() && r.FinalPoint == final.ToUpper()
                select r;

            //а с помощью этой чудо-конструкции формируем список тех, которые отправляются в указанный день недели
            foreach (var route in routes)
            {
                List<string> days = new List<string>();

                if (route.Monday)
                    days.Add("Monday");
                if (route.Tuesday)
                    days.Add("Tuesday");
                if (route.Wednesday)
                    days.Add("Wednesday");
                if (route.Thusday)
                    days.Add("Thusday");
                if (route.Friday)
                    days.Add("Friday");
                if (route.Saturday)
                    days.Add("Saturday");
                if (route.Sunday)
                    days.Add("Sunday");
                        
               foreach (string day in days)
                {
                    if (day == dateforsearch)
                        RoutesToReturn.Add(route);
                }           
            }
            return GetSeats(RoutesToReturn, DateFromForm);
        }

        public IEnumerable<Route> GetSeats(List<Route> routes, DateTime date)
        {
            var tickets = db.BoughtTickets.Where(x => x.BuyDay == date);

            foreach(var route in routes)
            {
                foreach(var ticket in tickets)
                {
                    if (ticket.RouteId == route.Id)
                        route.Seats--;
                    if (route.Seats <= 0)
                        routes.Remove(route);
                }
            }
            return routes;
        }
            
        }
    }

