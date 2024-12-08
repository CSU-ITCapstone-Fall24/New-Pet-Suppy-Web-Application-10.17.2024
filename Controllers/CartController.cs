using Microsoft.AspNetCore.Mvc;
using Pet_Web_Application_10._12._24_F.Data.Model;
using Pet_Web_Application_10._12._24_F.Models.Cart;
using System.Collections.Generic;

namespace Pet_Web_Application_10._12._24_F.Controllers
{
    public class CartController(ShoppingCart shoppingCart) : Controller
    {
        private readonly ShoppingCart _shoppingCart = shoppingCart;

        public Product GetProduct(int productId, string productName, string shortDescription, string longDescription, string imageUrl, string imageThumbnailUrl, int productInstock, int categoryId, string categoryName, string categoryDescription, List<Dogs> breed, bool isPreferredDog)
        {
            Category category = new()
            {
                Id = categoryId,
                CategoryName = categoryName,
                Description = categoryDescription,
                Products = [],
                Categories = [],
                Breed = breed
            };

            Product product = new()
            {
                Id = productId,
                Name = productName,
                ShortDescription = shortDescription,
                LongDescription = longDescription,
                ImageUrl = imageUrl,
                ImageThumbnailUrl = imageThumbnailUrl,
                ProductInstock = productInstock,
                CategoryId = categoryId,
                Category = category,
                IsPreferredDog = isPreferredDog
            };
            return product;
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, string productName, int quantity, decimal price)
        {
            var breed = new List<Dogs>
            {
                new() {
                    Name = "Golden Retriever",
                    ShortDescription = "Friendly and intelligent breed",
                    LongDescription = "Golden Retrievers are friendly, intelligent, and devoted. They are great family pets and excellent with children.",
                    ImageUrl = Url.Content("~/images/golden_retriever.jpg"),
                    ImageThumbnailUrl = Url.Content("~/images/golden_retriever_thumb.jpg"),
                    IsPreferredDog = true
                }
            };
            var product = GetProduct(productId, productName, "Short description", "Long description", Url.Content("~/images/product_image.jpg"), Url.Content("~/images/product_image_thumb.jpg"), 10, 1, "Category Name", "Category Description", breed, true);
            _shoppingCart.AddItem(productId, productName, quantity, price, product);
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            _shoppingCart.RemoveItem(productId);
            return RedirectToAction("Cart");
        }

        public IActionResult Index()
        {
            var model = new IndexModel
            {
                ShoppingCart = _shoppingCart
            };
            return View(model);
        }

        public IActionResult Cart()
        {
            var model = new CartViewModel
            {
                ShoppingCart = _shoppingCart
            };

            ViewData["Title"] = "Your Shopping Cart";
            ViewData["Message"] = "Here are the items in your cart.";

            return View(model);
        }
    }
}