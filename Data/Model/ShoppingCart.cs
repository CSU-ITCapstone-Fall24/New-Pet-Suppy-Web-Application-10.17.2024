namespace Pet_Web_Application_10._12._24_F.Data.Model
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public int ItemCount
        {
            get
            {
                return Items.Sum(item => item.Quantity);
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return Items.Sum(item => item.Price * item.Quantity);
            }
        }
        public required string ShippingAddress { get; set; }
        public required string PaymentMethod { get; set; }
        public required string BillingAddress { get; set; }

        public void AddItem(int productId, string productName, int quantity, decimal price)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
            {
                Items.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = productName,
                    Quantity = quantity,
                    Price = price
                });
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
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}