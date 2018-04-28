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
        public ActionResult LoginForm()
        {
            return PartialView();
        }


        [HttpPost]
        public ActionResult LoginForm(UserViewModel usermodel)
        {
            var user = UserRepository.FindUser(usermodel.Name);

            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(user.Login, true);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return PartialView("LoginForm");
        }



        public JsonResult IsLogin()
        {
            if (User.Identity.IsAuthenticated)            
                return Json(true, JsonRequestBehavior.AllowGet);
            else
                return Json(false, JsonRequestBehavior.AllowGet);

        }

        

        
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}