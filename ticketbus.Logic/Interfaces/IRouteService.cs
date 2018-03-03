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
        
        IEnumerable<RouteDTO> GetFindedRoutes(string start, string final, DateTime date);
    }
}
