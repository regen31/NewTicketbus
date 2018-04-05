using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ticketbus.Domain.Entities;

namespace ticketbus.Domain.EFContext
{
    class DBInitializer: DropCreateDatabaseAlways<BusContext>
    {

        protected override void Seed(BusContext context)
        {
            List<Route> routes = new List<Route> { new Route() { StartPoint = "БРЕСТ", FinalPoint = "МИНСК", DepartureTime = "13.00", ArrivalTime = "15.00", Seats=50, Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
                new Route() { StartPoint = "МИНСК", FinalPoint = "БРЕСТ", DepartureTime = "13.00", ArrivalTime = "15.00", Seats=50, Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
                new Route() { StartPoint = "БРЕСТ", FinalPoint = "БЕЛОВЕЖСКАЯ ПУЩА", DepartureTime = "13.00", ArrivalTime = "15.00", Seats=50, Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
                new Route() { StartPoint = "БЕЛОВЕЖСКИЙ", FinalPoint = "МИНСК", DepartureTime = "13.00", ArrivalTime = "15.00", Seats=50, Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
                new Route() { StartPoint = "БРЕСТ", FinalPoint = "ВЕЛЬЯМОВИЧИ", DepartureTime = "13.00", ArrivalTime = "15.00", Seats=50, Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
                new Route() { StartPoint = "БРЕСТ", FinalPoint = "ВЫСОКОЕ", DepartureTime = "13.00", ArrivalTime = "15.00", Seats=50, Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
                new Route() { StartPoint = "ВЫСОКОЕ", FinalPoint = "МИНСК", DepartureTime = "13.00", ArrivalTime = "15.00", Seats=50, Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
                new Route() { StartPoint = "БРЕСТ", FinalPoint = "ДОМАЧЕВО", DepartureTime = "13.00", ArrivalTime = "15.00", Seats=50, Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
                new Route() { StartPoint = "БРЕСТ", FinalPoint = "ЖАБИНКА", DepartureTime = "13.00", ArrivalTime = "15.00", Seats=50, Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
        };
            List<NewsItem> news = new List<NewsItem> {
                new NewsItem() { Date = DateTime.Now.Date, Text = "Какая замечательная новость" },
                new NewsItem() { Date = DateTime.Now.Date, Text = "Какая замечательная новость" },
                new NewsItem() { Date = DateTime.Now.Date, Text = "Какая удивительная  новость" },
                new NewsItem() { Date = DateTime.Now.Date, Text = "Какая восхитительная поразительная отвратительная новость" },
        };

            Role r1 = new Role() { Name = "admin" };
            context.Roles.Add(r1);
            context.SaveChanges();
            User user1 = new User() { Login = "admin", Password = "1234", UserRole=r1};
            

            context.Routes.AddRange(routes);
            context.NewsItems.AddRange(news);
            context.Users.Add(user1);
            context.SaveChanges();
        }
        
    }
}
