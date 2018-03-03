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

        

        public IEnumerable<RouteDTO> GetFindedRoutes(string start, string final, DateTime date)
        {
            List<RouteDTO> RoutesForReturn = new List<RouteDTO>();

            var routes = RouteRepository.FindRoutes(start, final, date);

            foreach(var route in routes)
            {
                RouteDTO dto = new RouteDTO()
                {
                    StartPoint = route.StartPoint,
                    FinalPoint = route.FinalPoint,
                    DepartureTime = route.DepartureTime,
                    ArrivalTime = route.ArrivalTime,
                };
                RoutesForReturn.Add(dto);             
            }
            return RoutesForReturn;
        }
    }
}
