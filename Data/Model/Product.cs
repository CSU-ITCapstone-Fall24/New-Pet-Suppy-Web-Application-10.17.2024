using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Web_Application_10._12._24_F.Data.Model
{
    public class Product
    {


        public int ProductId { get; set; }
        public required string Name { get; set; }
        public required string ShortDescription { get; set; }
        public required string LongDescription { get; set; }
        public decimal Price { get; set; }
        public required string ImageUrl { get; set; }
        public required string ImageThumbnailUrl { get; set; }
        public required bool IsPreferredDog { get; set; }
        public int ProductInstock { get; set; }
        public required int CategoryId { get; set; }
        public virtual required Category Category { get; set; }
        public int Id { get; internal set; }
    }
}