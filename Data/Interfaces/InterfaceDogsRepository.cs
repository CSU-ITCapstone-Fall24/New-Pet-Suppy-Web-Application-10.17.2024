using Pet_Web_Application_10._12._24_F.Data.Model;

namespace Pet_Web_Application_10._12._24_F.Data.Interfaces
{
    public interface InterfaceDogsRepository
    {
        IEnumerable<Dog> Dogs { get; set; }
        IEnumerable<Dog> PrefferedDog { get; set; }
        Product GetDogById(int dogId);
    }
}
