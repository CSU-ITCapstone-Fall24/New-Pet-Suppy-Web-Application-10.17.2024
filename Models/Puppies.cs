using System.ComponentModel.DataAnnotations;


namespace Pet_Web_Application_10._12._24_F.Models
{
    public class Puppies
    {
        public int Id { get; set; }

        [Required]
        [MaxLength (150)]
        [Display(Name = "Breed's Name")]
        [DataType(DataType.Text)]

        public string? BreedName { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Product Name")]
        [DataType(DataType.Text)]

        public string? ProductName { get; set; }


        [Required]
        [MaxLength(150)]
        [Display(Name = "Puppy Availability")]
        [DataType(DataType.Text)]


        public string? MyPuppy {  get; set; }




        [Required]
        [Display(Name = "Product Price")]
        [DataType(DataType.Currency)]

        public int PuppyPrice { get; set; }

      

        

    }
}
