using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ticketbus.WEB.Models
{
    public class QIWIViewModel
    {
        public OrderInfoViewModel OrderInfo { get; set; }


        [Required]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
    }
}