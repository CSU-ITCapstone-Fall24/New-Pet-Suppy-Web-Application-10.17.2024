


namespace Pet_Web_Application_10._12._24_F.Data.Model
{
    public class ShoppingCart
    {
        // List of items in the shopping cart
        public List<CartItem> Items { get; private set; } = [];

        // Properties for additional details
        public required string ShippingAddress { get; set; }
        public required string PaymentMethod { get; set; }
        public required string BillingAddress { get; set; }

        // Get the total number of items in the cart
        public int ItemCount => Items.Sum(item => item.Quantity);

        // Get the total price of all items in the cart
        public decimal TotalPrice => Items.Sum(item => item.Price * item.Quantity);

        // Add an item to the shopping cart
        public void AddItem(int productId, string productName, int quantity, decimal price)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity; // Increment quantity if the item already exists
            }
            else
            {
                Items.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = productName,
                    Quantity = quantity,
                    Price = price
                });
            }
        }

        // Remove an item from the shopping cart by ProductId
        public void RemoveItem(int productId)
        {
            Items.RemoveAll(i => i.ProductId == productId);
        }

        // Update the quantity of an item in the shopping cart
        public void UpdateItemQuantity(int productId, int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null && quantity > 0)
            {
                existingItem.Quantity = quantity;
            }
            else if (existingItem != null && quantity <= 0)
            {
                // If the quantity is zero or less, remove the item
                RemoveItem(productId);
            }
        }
    }

    // Represents an individual item in the shopping cart
    public class CartItem
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
