using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pet_Web_Application_10._12._24_F.Areas.Data;

namespace Pet_Web_Application_10._12._24_F.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<AppUser>(options)
    {
        public object? Donations { get; internal set; }
    }
}
