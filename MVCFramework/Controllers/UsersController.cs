using BusinessLayer.Interfaces;
using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFramework.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserBL userManager;
        public UsersController(IUserBL userManager)
        {
            this.userManager = userManager;
        }
        // GET: Users
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            try
            {
                var result = this.userManager.LoginUser(login);
                ViewBag.Message = "User login successfull";
                // return View();
                if (result == true)
                {
                    return RedirectToAction("AllBooks");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch (Exception)
            {
                return ViewBag.Message = "User login unsuccessfull";
            }
        }

    }
}