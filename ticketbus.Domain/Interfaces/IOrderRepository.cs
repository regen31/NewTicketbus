using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticketbus.Domain.Entities;

namespace ticketbus.Domain.Interfaces
{
   public interface IOrderRepository
    {
        IEnumerable<BoughtTicket> GetOrdersForRoute(int RouteId, DateTime date);
        void AddTicket(BoughtTicket ticket);
    }
}
