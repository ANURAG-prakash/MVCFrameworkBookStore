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
    public class BooksController : Controller
    {
        private readonly IBookBL booksManager;
        public BooksController(IBookBL booksManager)
        {
            this.booksManager = booksManager;
        }

        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllBooks()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult AllBooks(BookModel book)
        {
           
                var result = this.booksManager.GetAllBooks();
                return View(result);  
        }
        [Authorize]
        [HttpPost]
        public ActionResult Search(BookModel book)
        {
            try
            {
                var result = this.booksManager.Search(book);
                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        
        [HttpPost]
        public JsonResult AddToCart(CartModel cart)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;

                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var email = claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault()?.Value;
                    var result = this.booksManager.AddToCart(cart, email);
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


        
        [HttpPost]
        public JsonResult AddToWishlist(WishlistModel cart )
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;

                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var email = claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault()?.Value;
                    var result = this.booksManager.AddToWishlist(cart , email);
                    if (result != null)
                    {
                        return Json(new { status = true, Message = "Book added to Wishlist", Data = result });
                    }
                }
               
                    return Json(new { status = false, Message = "Book not added to Wishlist" });
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}