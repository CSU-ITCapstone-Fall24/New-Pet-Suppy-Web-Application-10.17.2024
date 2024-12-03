using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pet_Web_Application_10._12._24_F.Models;

namespace Pet_Web_Application_10._12._24_F.Data
{
    public class PuppiesandProductPurchasesContext : DbContext
    {
        public PuppiesandProductPurchasesContext (DbContextOptions<PuppiesandProductPurchasesContext> options)
            : base(options)
        {
        }

        public DbSet<Pet_Web_Application_10._12._24_F.Models.Puppies> Puppies { get; set; } = default!;
    }
}
