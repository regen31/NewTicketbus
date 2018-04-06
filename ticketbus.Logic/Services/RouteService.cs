using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticketbus.Domain.Entities;
using ticketbus.Domain.Interfaces;
using ticketbus.Logic.Interfaces;
using ticketbus.Logic.DTO;

namespace ticketbus.Logic.Services
{
    public class RouteService : IRouteService
    {
        IRouteRepository RouteRepository;

        public RouteService (IRouteRepository routeRepo)
        {
            RouteRepository = routeRepo;
        }


        public RouteDTO GetRoute(int id)
        {
            var route = RouteRepository.GetRoute(id);
            return new RouteDTO()
            {
                Id = route.Id,
                StartPoint = route.StartPoint,
                FinalPoint = route.FinalPoint,
                DepartureTime = route.DepartureTime,
                ArrivalTime = route.ArrivalTime,
                Seats = route.Seats,

                Monday = route.Monday,
                Tuesday = route.Tuesday,
                Wednesday = route.Wednesday,
                Thusday = route.Thusday,
                Friday = route.Friday,
                Saturday = route.Saturday,
                Sunday = route.Sunday,
            };
        }

        public IEnumerable<RouteDTO> GetAllRoutes()
        {
            List<RouteDTO> All = new List<RouteDTO>();
            var AllRoutes = RouteRepository.GetAll();

            foreach (var route in AllRoutes)
            {
                All.Add(new RouteDTO() {
                    Id = route.Id,
                    StartPoint = route.StartPoint,
                    FinalPoint = route.FinalPoint,
                    DepartureTime = route.DepartureTime,
                    ArrivalTime = route.ArrivalTime,
                    Seats = route.Seats,

                    Monday = route.Monday,
                    Tuesday = route.Tuesday,
                    Wednesday = route.Wednesday,
                    Thusday = route.Thusday,
                    Friday = route.Friday,
                    Saturday = route.Saturday,
                    Sunday = route.Sunday,
                });
            }
            return All;
        }

        public void CreateRoute(RouteDTO route)
        {
           
                Route CreatedRoute = new Route()
                {
                    Id = route.Id,
                    StartPoint = route.StartPoint,
                    FinalPoint = route.FinalPoint,
                    DepartureTime = route.DepartureTime,
                    ArrivalTime = route.ArrivalTime,
                    Seats = route.Seats,

                    Monday = route.Monday,
                    Tuesday = route.Tuesday,
                    Wednesday = route.Wednesday,
                    Thusday = route.Thusday,
                    Friday = route.Friday,
                    Saturday = route.Saturday,
                    Sunday = route.Sunday,
                };
                 RouteRepository.UpdateRoute(CreatedRoute);
        }


        public void Update(RouteDTO route)
        {
            var RouteFromDB = RouteRepository.GetRoute(route.Id);

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

            RouteRepository.UpdateRoute(RouteFromDB);
        }


        public void DeleteRoute(int id)
        {
            RouteRepository.Delete(id);
        }

        public IEnumerable<RouteDTO> GetFindedRoutes(string start, string final, DateTime date)
        {
            List<RouteDTO> RoutesForReturn = new List<RouteDTO>();

            var routes = RouteRepository.FindRoutes(start, final, date);

            foreach(var route in routes)
            {
                RouteDTO dto = new RouteDTO()
                {
                    Id = route.Id,
                    StartPoint = route.StartPoint,
                    FinalPoint = route.FinalPoint,
                    DepartureTime = route.DepartureTime,
                    ArrivalTime = route.ArrivalTime,
                    Seats = route.Seats,
                };
                RoutesForReturn.Add(dto);             
            }
            return RoutesForReturn;
        }
    }
}
