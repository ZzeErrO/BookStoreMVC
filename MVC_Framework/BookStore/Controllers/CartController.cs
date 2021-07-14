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

        [Authorize]
        public ActionResult AllCartBooks()
        {
            var identity = User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var email = claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault()?.Value;

                List<GetCartBooks> cartBooks = this.cartManager.GetAllBooks(email);
                return PartialView("CartBooks", cartBooks);
            }
            return this.HttpNotFound();
        }

        [Authorize]
        [HttpPost]
        public JsonResult Checkout(List<Cart> cart)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;

                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var email = claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault()?.Value;

                    var result = this.cartManager.Checkout(email);

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