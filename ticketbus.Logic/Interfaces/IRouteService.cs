using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticketbus.Logic.DTO;

namespace ticketbus.Logic.Interfaces
{
    public interface IRouteService
    {
        RouteDTO GetRoute(int id);
        IEnumerable<RouteDTO> GetAllRoutes();
        void CreateRoute(RouteDTO route);
        void Update(RouteDTO route);
        void DeleteRoute(int id);
        IEnumerable<RouteDTO> GetFindedRoutes(string start, string final, DateTime date);
    }
}
