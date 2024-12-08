


using Stripe;

namespace Pet_Web_Application_10._12._24_F.Data.Model
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; set; } = [];

        public required string ShippingAddress { get; set; }
        public required string PaymentMethod { get; set; }
        public required string BillingAddress { get; set; }

        public void AddItem(int productId, string productName, int quantity, decimal price, Product product)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
            {
                Items.Add(new ShoppingCartItem(productId, productName, quantity, price, product));
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void RemoveItem(int productId)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        public decimal TotalPrice => Items.Sum(item => item.TotalPrice);

        public int ItemCount => Items.Sum(item => item.Quantity);
    }
}