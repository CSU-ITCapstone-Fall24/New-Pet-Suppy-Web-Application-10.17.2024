namespace Pet_Web_Application_10._12._24_F.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Subject { get; set; }
        public required string Message { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}