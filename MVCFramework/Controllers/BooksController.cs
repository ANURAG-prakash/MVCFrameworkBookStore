using BusinessLayer.Interfaces;
using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET: Books
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
    }
}