using System.Collections.Generic;
using System.Linq;
using Pet_Web_Application_10._12._24_F.Data.Model;
using Pet_Web_Application_10._12._24_F.Models;

namespace Pet_Web_Application_10._12._24_F.Data.Model
{
    public class CartService : ICartService
    {
        private readonly List<ShoppingCartItem> _cartItems = [];

        public void AddToCart(ShoppingCartItem item)
        {
            _cartItems.Add(item);
        }

        public List<ShoppingCartItem> GetCartItems()
        {
            return _cartItems;
        }

        public void RemoveFromCart(int productId)
        {
            var item = _cartItems.FirstOrDefault(i => i.Product.Id == productId);
            if (item != null)
            {
                _cartItems.Remove(item);
            }
        }

        public decimal GetTotalPrice()
        {
            return _cartItems.Sum(item => item.TotalPrice);
        }
    }
}