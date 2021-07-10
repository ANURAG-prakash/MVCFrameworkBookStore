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
    public class WishlistController : Controller
    {

        private readonly IWishlistBL wishlistManager;
        public WishlistController(IWishlistBL booksManager)
        {
            this.wishlistManager = booksManager;
        }
       
        // GET: Wishlist
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WishlistBooks()
        {
            return View();
        }
        [HttpGet]
        public ActionResult WishlistBooks(GetWishlist books)
        {
            try
            {
                var result = this.wishlistManager.WishlistBooks();
                ViewBag.Message = "";
                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public JsonResult WishlisttoCart(CartModel cart)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;

                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var email = claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault()?.Value;
                    var result = this.wishlistManager.WishlistToCart(cart, email);
                    if (result != null)
                    {
                        return Json(new { status = true, Message = "Book added to cart", Data = result });
                    }
                }

                return Json(new { status = false, Message = "Book not added to cart" });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}