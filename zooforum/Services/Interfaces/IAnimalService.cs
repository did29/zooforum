using zooforum.Services.ViewModels;

namespace zooforum.Services.Interfaces
{
    public interface IAnimalService
    {
        Task DeleteAnimal(string id);
        Task CreateAnimal(AnimalViewModel model);
        AnimalViewModel UpdateById(string id);
        Task UpdateAnimal(AnimalViewModel model);
    }
}
