using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pet_Web_Application_10._12._24_F.Areas.Data;
using Pet_Web_Application_10._12._24_F.Controllers;
using Pet_Web_Application_10._12._24_F.Models;

namespace Pet_Web_Application_10._12._24_F.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ContactMessages = Set<ContactMessage>();
            Donations = Set<Donation>();
        }

        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Donation> Donations { get; set; }
    }
}