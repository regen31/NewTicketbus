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

        [ChildActionOnly]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return PartialView("LoginOK", new UserViewModel() {Name = User.Identity.Name });
            }

            return PartialView("LoginNot");
        }

        [HttpPost]
        public ActionResult Login(UserViewModel usermodel)
        {
            var user = UserRepository.FindUser(usermodel.Name);

            if (user != null && user.Password==usermodel.Password )
            {
                FormsAuthentication.SetAuthCookie(user.Login, true);
            }            
            return RedirectToAction("Index", "Home");
           
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}