using System.Collections.Generic;
using Pet_Web_Application_10._12._24_F.Data.Model;

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

        public decimal GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void RemoveFromCart(int productId)
        {
            throw new NotImplementedException();
        }
    }
}