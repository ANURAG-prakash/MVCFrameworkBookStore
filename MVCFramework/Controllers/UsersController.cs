using BusinessLayer.Interfaces;
using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Principal;

namespace MVCFramework.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserBL userManager;
        private const string Secret = "my_secret_key_12345";
        public UsersController(IUserBL userManager )
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


        [AllowAnonymous]
        [HttpPost]
        public JsonResult Login(LoginModel login)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = "http://localhost:44301",
                    Audience = "http://localhost:44301",
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("email", login.Email),
                    new Claim("ServiceType", "Users"),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(1440),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                var result = this.userManager.LoginUser(login);
                ViewBag.Token = tokenString;
               
                if (result == true)
                {
                   

                    return new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { result = "success", Token = tokenString }
                    };

                
                }
                else
                {
                    return new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { result = "failure" }
                    };
                }

            }
            catch (Exception ex)
            {
                return new JsonResult()
                {
                    Data = ex.Message
                };
            }

        }
        public ActionResult LoginUser(LoginModel loginuser)
        {
            return View(loginuser);
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