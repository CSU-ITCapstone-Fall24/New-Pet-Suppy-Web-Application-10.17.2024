using System.ComponentModel.DataAnnotations;

namespace Pet_Web_Application_10._12._24_F.Controllers
{
    public class Donation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string DonorName { get; set; }

        [Required]
        [CreditCard]
        public required string CreditCardNumber { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a value greater than 0")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 3)]
        public required string CVV { get; set; }

        [Required]
        public required string BillingAddress { get; set; }

        [Required]
        public required string MailingAddress { get; set; }
    }
}