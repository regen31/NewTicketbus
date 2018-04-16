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
    public class OrderService : IOrderService
    {
        IOrderRepository OrderRepository;

        public OrderService(IOrderRepository repo)
        {
            OrderRepository = repo;
        }

        public IEnumerable<BoughtTicketDTO> GetOrdersForRoute(int RouteId, DateTime date)
        {
            var ordersFromDB = OrderRepository.GetOrdersForRoute(RouteId, date);
            List<BoughtTicketDTO> TicketDTOList = new List<BoughtTicketDTO>();


            foreach(var order in ordersFromDB)
            {
                TicketDTOList.Add(new BoughtTicketDTO() {
                    RouteId = order.RouteId,
                    Buyer = order.Buyer,
                    SeatId = order.SeatId,
                    StartPoint = order.StartPoint,
                    FinalPoint = order.FinalPoint,
                    BuyDay = order.BuyDay,
                });
            }

            return TicketDTOList;
        }


        public void AddBoughtTicket(BoughtTicketDTO ticket)
        {
            OrderRepository.AddTicket(new BoughtTicket
            {

                RouteId = ticket.RouteId,
                Buyer = ticket.Buyer,
                SeatId = ticket.SeatId,
                StartPoint = ticket.StartPoint,
                FinalPoint = ticket.FinalPoint,
                BuyDay = ticket.BuyDay,
            });
        }
    }
}
