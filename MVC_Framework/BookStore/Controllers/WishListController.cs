using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        [Authorize]
        public ActionResult AllWishListBooks()
        {
            var identity = User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var email = claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault()?.Value;

                List<GetWishListBooks> cartBooks = this.wishlistManager.GetAllBooks(email);
                return PartialView("AllWishListBooks", cartBooks);
            }

            return this.HttpNotFound();
        }
        [Authorize]
        [HttpDelete]
        public JsonResult DeleteWishBook(GetWishListBooks book)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;

                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var email = claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault()?.Value;

                    var result = this.wishlistManager.DeleteWishBook(book.WishListId);

                    if (result != false)
                    {
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