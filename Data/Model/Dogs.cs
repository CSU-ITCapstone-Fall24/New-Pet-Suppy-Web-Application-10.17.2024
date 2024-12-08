using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Pet_Web_Application_10._12._24_F.Data.Model
{
    public class Dogs
    {
        // Parameterless constructor
        public Dogs()
        {
        }

        // Constructor with parameters
        public Dogs(string name, string shortDescription, string longDescription, string imageUrl, string imageThumbnailUrl, bool isPreferredDog)
        {
            Name = name;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
            ImageUrl = imageUrl;
            ImageThumbnailUrl = imageThumbnailUrl;
            IsPreferredDog = isPreferredDog;
        }

        public required string Name { get; set; }
        public required string ShortDescription { get; set; }
        public required string LongDescription { get; set; }
        public required string ImageUrl { get; set; }
        public required string ImageThumbnailUrl { get; set; }
        public required bool IsPreferredDog { get; set; }
    }
}