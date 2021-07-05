﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult AllCartBooks()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AllCartBooks(GetCartBooks books)
        {
            try
            {
                var result = this.cartManager.GetAllBooks();
                ViewBag.Message = "";
                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public JsonResult Checkout(List<Cart> cart)
        {
            try
            {
                var result = this.cartManager.Checkout();
                if (result != false)
                {
                    Url.Action("Order", "Order");
                    return Json(new { status = true, Message = "Checkout done", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "Checkout problem", Data = result });
                }   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}