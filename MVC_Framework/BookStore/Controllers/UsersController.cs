using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Interface;
using ModelsLayer.Models;

namespace BookStore.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserBL userManager;
        public UsersController(IUserBL userManager)
        {
            this.userManager = userManager;
        }
        // GET: Users
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            try
            {
                var result = this.userManager.Login(login);
                ViewBag.Message = "User login successfull";
                // return View();
                if (result == true)
                {
                    return RedirectToAction("AllBooks", "Books");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch (Exception)
            {
                return ViewBag.Message = "User login unsuccessfull";
            }
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            try
            {
                var result = this.userManager.Register(register);
                ViewBag.Message = "User registered successfully";
                // return View();
                if (result == true)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return RedirectToAction("Register");
                }
            }
            catch (Exception)
            {
                return ViewBag.Message = "User registration unsuccessfull";
            }
        }

    }
}