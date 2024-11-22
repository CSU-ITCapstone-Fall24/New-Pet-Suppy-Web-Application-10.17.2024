using Microsoft.AspNetCore.Identity;

namespace Pet_Web_Application_10._12._24_F.Areas.Data
{
    public class AppUser : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        // Add any other custom properties here
    }
}