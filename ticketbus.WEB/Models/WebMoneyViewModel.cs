using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ticketbus.WEB.Models
{
    public class WebMoneyViewModel
    {
        public OrderInfoViewModel OrderInfo { get; set; }

        [Required]
        [Display(Name ="WMID")]
        public string Wmid { get; set; }

        [Required]
        [Display(Name ="Пароль")]
        [DataType(DataType.Password)]
        public string WMPassword { get; set; }
    }
}