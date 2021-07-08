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
        public ActionResult Login(LoginModel login)
        {
            try
            {
               
                    var result = this.userManager.LoginUser(login);
                if (result == false)
                {
                     ViewBag.Message = "Username or password is incorrect";
                    return Redirect("https://localhost:44301/Users/Login");

                }
                    

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = "self",
                    Audience = "http://localhost",
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                     
                    new Claim(ClaimTypes.Email, login.Email),
                    new Claim("ServiceType", "User"),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(600),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                ViewBag.Message = tokenString;
                return Redirect("https://localhost:44301/Books/AllBooks");
                    
              }
            catch (Exception)
            {
                return ViewBag.Message = "User login unsuccessfull";
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