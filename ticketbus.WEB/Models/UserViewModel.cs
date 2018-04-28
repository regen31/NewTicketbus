using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ticketbus.WEB.ValidationHelpers;

namespace ticketbus.WEB.Models
{
    [Password(ErrorMessage ="Некорректные данные")]
    public class UserViewModel
    {
        [Required(ErrorMessage = "Введите логин")]
        [Display(Name="Логин")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }        
    }
}