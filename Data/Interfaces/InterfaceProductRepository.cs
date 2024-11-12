using Pet_Web_Application_10._12._24_F.Data.Model;

namespace Pet_Web_Application_10._12._24_F.Data.Interfaces
{
    public interface InterfaceProductRepository
    {
        IEnumerable<Product> Products { get; set; }
        IEnumerable<Product> PrefferedProduducts { get; set; }
        Product GetProductById(int productId);
    }
}
