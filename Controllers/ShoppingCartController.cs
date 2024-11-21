using Microsoft.AspNetCore.Mvc;
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
            var cartItems = _cartService.GetCart();
            var total = _cartService.GetTotal();
            ViewData["Total"] = total;
            return View(cartItems);
        }

        public IActionResult AddToCart(int productId)
        {
            // Fetch the product from the database (this is a placeholder)
            var product = new Product { Id = productId, Name = "Product " + productId, Price = 10.00m }; // Example
            _cartService.AddToCart(product);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            _cartService.RemoveFromCart(productId);
            return RedirectToAction("Index");
        }
    }
}
