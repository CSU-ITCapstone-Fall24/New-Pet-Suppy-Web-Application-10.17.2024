﻿using Pet_Web_Application_10._12._24_F.Data.Model;

namespace Pet_Web_Application_10._12._24_F.Data.Interfaces
{
   

    public interface INterfaceDogsRepository
    {
        IEnumerable<Dogs> Dogs { get; set; }
        IEnumerable<Dogs> PrefferedDog { get; set; }
        Dogs GetDogById(int dogId);
    }
}
