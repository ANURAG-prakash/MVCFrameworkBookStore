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

        public ActionResult Register()
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
                //  return Redirect("https://localhost:44301/Books/AllBooks");
                return View();



            }
            catch (Exception )
            {
                ViewBag.Message = "User login unsuccessfull";
                // return Redirect("https://localhost:44301/Users/Login");
                return View();
            }
        }


        [HttpPost]
        public ActionResult Register(RegistationModel register)
        {
            try
            {
                var result = this.userManager.RegisterUser(register);
                 ViewBag.Message = "User registered successfully";
                return Redirect("https://localhost:44301/Users/Login");


            }
            catch (Exception)
            {
                return Redirect("https://localhost:44301/Users/Register");
            }
        }

    }
}