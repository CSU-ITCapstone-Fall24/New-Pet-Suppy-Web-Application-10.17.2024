using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Pet_Web_Application_10._12._24_F.Models;

namespace Pet_Web_Application_10._12._24_F.Services
{
    public class CartService
    {
        private readonly ISession _session;

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext?.Session ?? throw new ArgumentNullException(nameof(httpContextAccessor.HttpContext.Session), "Session is null");
        }

        private List<CartItem> GetCartItems()
        {
            var cart = _session.GetString("Cart");
            return string.IsNullOrEmpty(cart) ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(cart) ?? new List<CartItem>();
        }

        private void SaveCartItems(List<CartItem> cartItems)
        {
            _session.SetString("Cart", JsonConvert.SerializeObject(cartItems));
        }

        public void AddToCart(Product product)
        {
            var cartItems = GetCartItems();
            var existingItem = cartItems.FirstOrDefault(item => item.Product.Id == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cartItems.Add(new CartItem { Product = product, Quantity = 1 });
            }

            SaveCartItems(cartItems);
        }

        public void RemoveFromCart(int productId)
        {
            var cartItems = GetCartItems();
            var itemToRemove = cartItems.FirstOrDefault(item => item.Product.Id == productId);

            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
                SaveCartItems(cartItems);
            }
        }

        public List<CartItem> GetCart()
        {
            return GetCartItems();
        }

        public decimal GetTotal()
        {
            var cartItems = GetCartItems();
            return cartItems.Sum(item => item.Product.Price * item.Quantity);
        }
    }
}