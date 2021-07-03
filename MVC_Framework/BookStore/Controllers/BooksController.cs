using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Interface;
using ModelsLayer.Models;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksBL booksManager;
        public BooksController(IBooksBL booksManager)
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
        public ActionResult AllBooks(Books book)
        {
            try
            {
                var result = this.booksManager.GetAllBooks();
                ViewBag.Message = "";
                return View(result);
            }
            catch (Exception)
            {
                return ViewBag.Message = "unsucessfully";
            }
        }

        [HttpPost]
        public JsonResult AddToCart(Cart cart)
        {
            try
            {
                var result = this.booksManager.AddToCart(cart);
                if (result != null)
                {
                    return Json(new { status = true, Message = "Book added to cart", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "Book not added to cart", Data = result });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}