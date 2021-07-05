using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Interface;
using ModelsLayer.Models;

namespace BookStore.Controllers
{
    public class WishListController : Controller
    {
        private readonly IWishListBL wishlistManager;
        public WishListController(IWishListBL booksManager)
        {
            this.wishlistManager = booksManager;
        }
        // GET: WishList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllWishListBooks()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AllWishListBooks(GetWishListBooks books)
        {
            try
            {
                var result = this.wishlistManager.GetAllBooks();
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