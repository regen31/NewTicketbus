﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticketbus.Domain.Entities
{
   public class BoughtTicket
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public string Buyer { get; set; }
        public int SeatId { get; set; }

        public string StartPoint { get; set; }
        public string FinalPoint { get; set; }
        public DateTime BuyDay { get; set; }

        public DateTime AddTime { get; set; }
        public string Status { get; set; }
    }
}
