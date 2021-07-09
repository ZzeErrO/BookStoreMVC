using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Interface;
using Microsoft.IdentityModel.Tokens;
using ModelsLayer.Models;

namespace BookStore.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserBL userManager;

        private readonly string _secret;
        private readonly string _issuer;

        public UsersController(IUserBL userManager)
        {
            this.userManager = userManager;
            _secret = "Thisismysecretkey";
            _issuer = "https://localhost:44380";
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
        public JsonResult Login(Login login)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = _issuer,
                    Audience = _issuer,
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("email", login.Email),
                    new Claim("ServiceType", "Users"),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(1440),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                var result = this.userManager.Login(login);
                ViewBag.Token = tokenString;
                // return View();
                if (result == true)
                {
                    //return RedirectToAction("AllBooks", "Books");

                    return new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { result = "success", Token = tokenString }
                    };

                    //return this.View("Login", tokenvalue);
                }
                else
                {
                    return new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { result = "failure" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult()
                {
                    Data = ex.Message
                };
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