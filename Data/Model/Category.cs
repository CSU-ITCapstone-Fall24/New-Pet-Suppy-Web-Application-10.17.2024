using System;
using System.Collections.Generic;

namespace Pet_Web_Application_10._12._24_F.Data.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public required string Description { get; set; }
        public required List<Product> Products { get; set; }
        public required List<Category> Categories { get; set; }
        public required List<Dogs> Breed { get; set; }
        public string? Name { get; internal set; }
        public int Id { get; internal set; }
    }
}