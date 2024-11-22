using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Pet_Web_Application_10._12._24_F.Models;

namespace Pet_Web_Application_10._12._24_F.Services
{
    public class CartService
    {
        private readonly List<CartItem> _cartItems = new List<CartItem>();

        public IEnumerable<CartItem> GetCartItems() => _cartItems;

        public void AddToCart(Product product)
        {
            var cartItem = _cartItems.FirstOrDefault(item => item.ProductId == product.Id);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                _cartItems.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });
            }
        }

        public void RemoveFromCart(int productId)
        {
            var cartItem = _cartItems.FirstOrDefault(item => item.ProductId == productId);
            if (cartItem != null)
            {
                _cartItems.Remove(cartItem);
            }
        }

        public decimal GetTotal() => _cartItems.Sum(item => item.Price * item.Quantity);
    }
}