using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ticketbus.Logic.DTO;
using ticketbus.Logic.Interfaces;
using ticketbus.WEB.Models;

namespace ticketbus.WEB.ValidationHelpers
{
    public class PasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            IUserService Userrepository = DependencyResolver.Current.GetService<IUserService>();
            UserViewModel usermodel = value as UserViewModel;
            var user = Userrepository.FindUser(usermodel.Name);
            if (user == null || user.Login != usermodel.Name || user.Password != usermodel.Password)
                return false;
            else
                return true;



        }
    }
}