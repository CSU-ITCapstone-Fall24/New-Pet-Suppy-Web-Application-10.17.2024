using Pet_Web_Application_10._12._24_F.Data.Model;

namespace Pet_Web_Application_10._12._24_F.Data.Model
{
    public interface ICartService
    {
        void AddToCart(ShoppingCartItem item);
        List<ShoppingCartItem> GetCartItems();
      
       
    }
}