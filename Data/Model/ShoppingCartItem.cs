namespace Pet_Web_Application_10._12._24_F.Data.Model
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public required Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Product.Price * Quantity;
    }
}