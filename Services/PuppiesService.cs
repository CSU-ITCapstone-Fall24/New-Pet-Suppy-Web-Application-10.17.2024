using System.Collections.Generic;
using System.Linq;
using Pet_Web_Application_10._12._24_F.Models;

namespace Pet_Web_Application_10._12._24_F.Services
{
    public class PuppyService
    {
        private readonly List<Puppy> _puppies = new List<Puppy>
        {
            new Puppy { Id = 1, Name = "Buddy", Price = 100.00m, ImageUrl = "/images/puppy1.jpg" },
            new Puppy { Id = 2, Name = "Bella", Price = 150.00m, ImageUrl = "/images/puppy2.jpg" },
            new Puppy { Id = 3, Name = "Charlie", Price = 200.00m, ImageUrl = "/images/puppy3.jpg" }
        };

        public IEnumerable<Puppy> GetPuppies() => _puppies;

        public Puppy GetPuppyById(int id) => _puppies.FirstOrDefault(p => p.Id == id);
    }
}