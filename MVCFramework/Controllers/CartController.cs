using BusinessLayer.Interfaces;
using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var result = this.cartManager.CartBooks();
                ViewBag.Message = "";
                return View(result);
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
                var result = this.cartManager.Placeorder();
                if (result != false)
                {
                    
                    return Json(new { status = true, Message = "Orderplace done", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "Problem with orderplacing", Data = result });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}