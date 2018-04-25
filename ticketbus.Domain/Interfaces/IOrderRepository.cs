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
        void AddTickets(IEnumerable<BoughtTicket> tickets);
        void ChangeStatusChosenToBought(int RouteId, DateTime DepartDate, int[] seats);
        Task<List<BoughtTicket>> GetChosenTickets();
        void RemoveChosenTickets(ICollection<BoughtTicket> tickets);
    }
}
