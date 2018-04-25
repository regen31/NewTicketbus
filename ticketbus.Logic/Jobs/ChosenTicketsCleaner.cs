using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticketbus.Domain.Entities;
using ticketbus.Domain.Interfaces;
using ticketbus.Logic.Interfaces;
using System.Web.Mvc;
using Quartz;

namespace ticketbus.Logic.Jobs
{
    class ChosenTicketsCleaner :IJob
    {
        IOrderRepository OrderRepo = DependencyResolver.Current.GetService<IOrderRepository>();
        
        public async Task Execute (IJobExecutionContext context)
        {
            var tickets = await OrderRepo.GetChosenTickets();
            List<BoughtTicket> TicketsToRemove = new List<BoughtTicket>();

            if (tickets.Count > 0)
            {
                foreach (var ticket in tickets)
                {
                    if (ticket.AddTime.AddMinutes(10) < DateTime.Now)
                        TicketsToRemove.Add(ticket);
                }
            }
           OrderRepo.RemoveChosenTickets(TicketsToRemove);
        }
    }
}
