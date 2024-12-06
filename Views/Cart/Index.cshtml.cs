using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pet_Web_Application_10._12._24_F.Data.Model;
namespace Pet_Web_Application_10._12._24_F.Views.Cart
{
    public class IndexModel
    {
        public required ShoppingCart ShoppingCart { get; set; }
        // Add other properties as needed
    }
}