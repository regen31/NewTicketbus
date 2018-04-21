using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ticketbus.WEB.Models
{
    public class PaymentCardViewModel
    {
        public OrderInfoViewModel OrderInfo { get; set; }

        [Display(Name = "Номер карты:")]
        [Required]
        public string CardNumber { get; set; }
        
        [Display(Name ="Срок дейсвтия:")]
        [Required]
        public string Month { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public int CVV { get; set; }

        [Display(Name ="Владелец карты:")]
        [Required]
        public string Owner { get; set; }
    }
}