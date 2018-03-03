using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticketbus.Domain.Entities;

namespace ticketbus.Domain.Interfaces
{
    public interface IRouteRepository
    {
        
        
        IEnumerable<Route> FindRoutes(string start, string final, DateTime date);
        
    }
}
