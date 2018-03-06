using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ticketbus.WEB.Models
{
    public class NewsViewModel
    {
        [DataType(DataType.Date)]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Текст новости")]
        public string Text { get; set; }
    }
}