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

        
        
        //здесь какая-то жуть
        public IEnumerable<Route> FindRoutes(string start, string final, DateTime date)  
        {
            string dateforsearch = date.DayOfWeek.ToString();
            List<Route> RoutesToReturn = new List<Route>();

            //берем из базы маршруты, которые совпадают по точке отправления и точке назначения
            var routes =
                from r in db.Routes
                where r.StartPoint == start && r.FinalPoint == final
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
            return RoutesToReturn;
        }

            
        }
    }

