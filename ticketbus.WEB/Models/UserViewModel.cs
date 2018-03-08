using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ticketbus.WEB.Models
{
    public class UserViewModel
    {
        [Required]
        public string Name { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}