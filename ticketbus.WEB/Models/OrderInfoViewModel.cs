using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ticketbus.WEB.Models
{
    public class OrderInfoViewModel
    {
        [Display(Name = "Номер маршрута: ")]        
        public int RouteId { get; set; }

        [Display(Name = "Следование: ")]
        public string StartPoint { get; set; }
        public string FinalPoint { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Отправление: ")]
        public DateTime DepartDate { get; set; }
        public string DepartTime { get; set; }

        [Display(Name = "Заказано билетов: ")]
        public int SeatsCount { get; set; }

        
        public int[] ChosenSeats { get; set; }
    }
}