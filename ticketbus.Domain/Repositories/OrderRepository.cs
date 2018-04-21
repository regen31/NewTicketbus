using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticketbus.Domain.EFContext;
using ticketbus.Domain.Entities;
using ticketbus.Domain.Interfaces;

namespace ticketbus.Domain.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private BusContext db;

        public OrderRepository(string connectionString)
        {
            db = new BusContext(connectionString);
        }

         
        public IEnumerable<BoughtTicket> GetOrdersForRoute(int RouteId, DateTime date)
        {
            var orders =
                from order in db.BoughtTickets
                where order.RouteId == RouteId && order.BuyDay == date
                select order;

            return orders;
        }

        public void AddTickets(IEnumerable<BoughtTicket> tickets)
        {
            db.BoughtTickets.AddRange(tickets);
            db.SaveChanges();
        }

        public void ChangeStatusChosenToBought(int RouteId, DateTime DepartDate, int[] seats)
        {
            var tickets =
                from order in db.BoughtTickets
                where order.RouteId == RouteId && order.BuyDay == DepartDate
                select order;

            foreach(var ticket in tickets)
            {
                for (int i = 0; i < seats.Length; i++)
                {
                    if (ticket.SeatId == seats[i] && ticket.Status == "Chosen")

                    ticket.Status = "Bought";
                    ticket.AddTime = DateTime.Now;
                }
            }

            db.SaveChanges();
        }
    }
}
