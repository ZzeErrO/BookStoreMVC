using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Interface;
using ModelsLayer.Models;

namespace BookStore.Controllers
{
    public class SearchController : Controller
    {
        private readonly IBooksBL booksManager;

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchBooks()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AllBooks(string value)
        {
            //var email = User.Identity.IsAuthenticated;
            //ViewBag.Email = email;

            try
            {
                var result = this.booksManager.GetSearchBooks(value);
                ViewBag.Message = "";
                return View(result);
            }
            catch (Exception)
            {
                return ViewBag.Message = "unsucessfully";
            }
        }
    }
}