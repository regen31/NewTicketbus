using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ticketbus.WEB.ValidationHelpers;

namespace ticketbus.WEB.Models
{    
    public class RouteViewModel
    {
        public int Id { get; set; }
        [Required]
        public string StartPoint { get; set; }
        [Required]
        public string FinalPoint { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public int Seats { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime DateForSearch { get; set; }
    }
}