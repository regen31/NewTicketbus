using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ticketbus.Logic.Interfaces;
using ticketbus.WEB.Models;

namespace ticketbus.WEB.ValidationHelpers
{
    public class UsernameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            IUserService Userrepository = DependencyResolver.Current.GetService<IUserService>();
            UserRegisterViewModel usermodel = value as UserRegisterViewModel;
            var user = Userrepository.FindUser(usermodel.Name);
            if (user != null)
                return false;
            else
                return true;
        }
    }
}