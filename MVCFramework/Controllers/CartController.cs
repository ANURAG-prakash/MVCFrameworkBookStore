using BusinessLayer.Interfaces;
using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MVCFramework.Controllers
{
    public class CartController : Controller
    {


        private readonly ICartBL cartManager;
        public CartController(ICartBL booksManager)
        {
            this.cartManager = booksManager;
        }



        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CartBooks()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CartBooks(GetCart books)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;

                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var email = claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault()?.Value;

                    var result = this.cartManager.CartBooks(email);
                    ViewBag.Message = "";
                    return View(result);
                }
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public JsonResult Placeorder(List<CartModel> cart)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;


                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var email = claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault()?.Value;
                    var result = this.cartManager.Placeorder(email);
                    if (result != false)
                    {
                        RedirectToAction("Orderconfirm", "Order");
                        return Json(new { status = true, Message = "Checkout done", Data = result });
                    }

                }
                return Json(new { status = false, Message = "Checkout problem" });

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}