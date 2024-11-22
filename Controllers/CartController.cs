using Microsoft.AspNetCore.Mvc;
using Pet_Web_Application_10._12._24_F.Services;

public class CartController : Controller
{
    private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    public IActionResult Index()
    {
        var cartItems = _cartService.GetCartItems();
        ViewBag.Total = _cartService.GetTotal();
        return View(cartItems);
    }

    public IActionResult RemoveFromCart(int id)
    {
        _cartService.RemoveFromCart(id);
        return RedirectToAction("Index");
    }
}