using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticketbus.Logic.DTO;
using ticketbus.Logic.Interfaces;
using ticketbus.WEB.Models;
using System.Web.Security;

namespace ticketbus.WEB.Controllers
{
    public class AccountController : Controller
    {
        IUserService UserRepository;

        public AccountController(IUserService repo)
        {
            UserRepository = repo;
        }

        public ActionResult Login(string login)
        {
            var user = UserRepository.FindUser(login);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Login, true);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}