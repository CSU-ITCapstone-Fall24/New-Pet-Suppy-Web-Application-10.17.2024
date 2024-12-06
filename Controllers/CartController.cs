using Microsoft.AspNetCore.Mvc;
using Pet_Web_Application_10._12._24_F.Data.Model; // Ensure this namespace is included

namespace Pet_Web_Application_10._12._24_F.Controllers
{
    public class CartController(ShoppingCart shoppingCart) : Controller
    {
        private readonly ShoppingCart _shoppingCart = shoppingCart;

        [HttpPost]
        public IActionResult AddToCart(int productId, string productName, int quantity, decimal price)
        {
            _shoppingCart.AddItem(productId, productName, quantity, price);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            _shoppingCart.RemoveItem(productId);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View(_shoppingCart);
        }
    }
}