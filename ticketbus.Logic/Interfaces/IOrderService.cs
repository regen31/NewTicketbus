using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticketbus.Logic.DTO;

namespace ticketbus.Logic.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<BoughtTicketDTO> GetOrdersForRoute(int RouteId, DateTime date);
        void AddTickets(IEnumerable<BoughtTicketDTO> tickets);
        void ChangeStatusChosenToBought(int RouteId, DateTime DepartDate, int[] seats);
    }
}
