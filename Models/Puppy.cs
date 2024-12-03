namespace Pet_Web_Application_10._12._24_F.Models
{
    public class Puppy
    {
        public int Id { get; set; }
        public string? Name { get; set; }  // Make Name nullable
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }  // Make ImageUrl nullable
    }
}