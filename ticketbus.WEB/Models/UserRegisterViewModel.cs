using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ticketbus.WEB.ValidationHelpers;

namespace ticketbus.WEB.Models
{
    [Username(ErrorMessage = "Такой пользователь существует")]
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Введите логин")]
        [Display(Name = "Логин")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Required(ErrorMessage = "Подтвердите пароль")]
        [Display(Name = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}