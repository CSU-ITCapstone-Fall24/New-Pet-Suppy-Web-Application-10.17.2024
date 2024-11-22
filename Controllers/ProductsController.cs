using Microsoft.AspNetCore.Mvc;
using Pet_Web_Application_10._12._24_F.Models; // Add this line
using Pet_Web_Application_10._12._24_F.Services;

namespace Pet_Web_Application_10._12._24_F.Controllers
{
    public class ProductsController : Controller
    {
        private readonly CartService _cartService;

        public ProductsController(CartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10 },
                new Product { Id = 2, Name = "Product 2", Price = 20 }
            };
            return View(products);
        }

        public IActionResult AddToCart(int id)
        {
            var product = new Product { Id = id, Name = $"Product {id}", Price = id * 10 };
            _cartService.AddToCart(product);
            return RedirectToAction("Index");
        }
    }
}