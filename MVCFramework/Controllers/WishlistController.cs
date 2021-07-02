using BusinessLayer.Interfaces;
using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}