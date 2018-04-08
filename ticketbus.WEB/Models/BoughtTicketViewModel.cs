using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ticketbus.WEB.Models
{
    public class BoughtTicketViewModel
    {
        public int RouteId { get; set; }
        public string Buyer { get; set; }

        public string StartPoint { get; set; }
        public string FinalPoint { get; set; }

        [DataType(DataType.Date)]
        public DateTime BuyDay { get; set; }

    }
}