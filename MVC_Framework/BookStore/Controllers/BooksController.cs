using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer.Interface;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
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
            //var email = User.Identity.IsAuthenticated;
            //ViewBag.Email = email;

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

        [Authorize]
        [HttpPost]
        public JsonResult AddToCart(Cart cart)
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

        [Authorize]
        [HttpPost]
        public JsonResult AddToWishList(WishList wishList)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;

                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var email = claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault()?.Value;

                    var result = this.booksManager.AddToWishList(wishList, email);
                    if (result != null)
                    {
                        return Json(new { status = true, Message = "Book added to wishList", Data = result });
                    }
                }

                return Json(new { status = false, Message = "Book not added to wishList" });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult UploadImage(int BookId, HttpPostedFileBase image)
        {
            try
            {
                var imageUpload = CloudImageLink(image);
                bool result = this.booksManager.UploadImage(BookId, imageUpload);
                if (result == true)
                {
                    return Json(new { status = true, Message = "Image added ", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "image not added " });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string CloudImageLink(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return null;
            }
            var filepath = file.InputStream;
            string uniquename = Guid.NewGuid().ToString() + "_" + file.FileName;
            Account account = new Account("dywhtr8hk", "371652781151548", "1aVBjz0E-GdsHlguqwgk_spEyCo");
            Cloudinary cloud = new Cloudinary(account);
            var uploadparam = new ImageUploadParams()
            {
                File = new FileDescription(uniquename, filepath)
            };
            var uploadResult = cloud.Upload(uploadparam);
            return uploadResult.Url.ToString();
        }
    }
}