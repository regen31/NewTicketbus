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
            List<Route> routes = new List<Route> { new Route() { StartPoint = "брест", FinalPoint = "минск", DepartureTime = "13.00", ArrivalTime = "15.00", Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
                new Route() { StartPoint = "минск", FinalPoint = "минск", DepartureTime = "13.00", ArrivalTime = "15.00", Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
                new Route() { StartPoint = "брест", FinalPoint = "беловежская пуща", DepartureTime = "13.00", ArrivalTime = "15.00", Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
                new Route() { StartPoint = "беловежский", FinalPoint = "минск", DepartureTime = "13.00", ArrivalTime = "15.00", Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
                new Route() { StartPoint = "брест", FinalPoint = "вельямовичи", DepartureTime = "13.00", ArrivalTime = "15.00", Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
                new Route() { StartPoint = "брест", FinalPoint = "высокое", DepartureTime = "13.00", ArrivalTime = "15.00", Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
                new Route() { StartPoint = "высокое", FinalPoint = "минск", DepartureTime = "13.00", ArrivalTime = "15.00", Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
                new Route() { StartPoint = "брест", FinalPoint = "домачево", DepartureTime = "13.00", ArrivalTime = "15.00", Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
                new Route() { StartPoint = "брест", FinalPoint = "жабинка", DepartureTime = "13.00", ArrivalTime = "15.00", Monday = true, Tuesday = false, Wednesday = true, Thusday = true, Friday = false, Saturday = true, Sunday = true },
        };
            List<NewsItem> news = new List<NewsItem> {
                new NewsItem() { Date = DateTime.Now.Date, Text = "Какая замечательная новость" },
                new NewsItem() { Date = DateTime.Now.Date, Text = "Какая замечательная новость" },
                new NewsItem() { Date = DateTime.Now.Date, Text = "Какая удивительная  новость" },
                new NewsItem() { Date = DateTime.Now.Date, Text = "Какая восхитительная поразительная отвратительная новость" },
        };


            context.Routes.AddRange(routes);
            context.NewsItems.AddRange(news);
            context.SaveChanges();
        }
        
    }
}
