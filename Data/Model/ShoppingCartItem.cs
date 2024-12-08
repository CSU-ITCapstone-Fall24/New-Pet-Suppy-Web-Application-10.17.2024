namespace Pet_Web_Application_10._12._24_F.Data.Model
{
    public class ShoppingCartItem(int productId, string productName, int quantity, decimal price, Product product)
    {
        public int ProductId { get; } = productId;
        public string ProductName { get; set; } = productName;
        public int Quantity { get; set; } = quantity;
        public decimal Price { get; set; } = price;
        public Product Product { get; set; } = product;

        public decimal TotalPrice => Quantity * Price;
    }
}