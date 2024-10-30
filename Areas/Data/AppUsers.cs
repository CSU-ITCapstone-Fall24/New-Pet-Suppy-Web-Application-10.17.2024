using Microsoft.AspNetCore.Identity;

namespace Pet_Web_Application_10._12._24_F.Areas.Data
{
    public class AppUser : IdentityUser
    {

        public string FirstName { get; set; }

        public  string LastName { get; set; }

    }
}
