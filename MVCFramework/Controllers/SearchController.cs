using BusinessLayer.Interfaces;
using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFramework.Controllers
{
    public class SearchController : Controller
    {
        private readonly IBookBL booksManager;
        public SearchController(IBookBL booksManager)
        {
            this.booksManager = booksManager;
        }
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }

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
    }
}