﻿using Microsoft.AspNetCore.Mvc;
using Pet_Web_Application_10._12._24_F.Models;
using Pet_Web_Application_10._12._24_F.Services;
using System.Collections.Generic;

namespace Pet_Web_Application_10._12._24_F.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly CartService _cartService;

        public ShoppingCartController(CartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var cartItems = _cartService.GetCartItems();
            ViewBag.Total = _cartService.GetTotal();
            return View(cartItems);
        }

        public IActionResult AddToCart(int id)
        {
            var product = new Product { Id = id, Name = $"Product {id}", Price = id * 10 };
            _cartService.AddToCart(product);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Index");
        }
    }
}