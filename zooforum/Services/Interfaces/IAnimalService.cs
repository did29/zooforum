using zooforum.Services.ViewModels;

namespace zooforum.Services.Interfaces
{
    public interface IAnimalService
    {
        Task DeleteAnimal(string id);
        Task CreateAnimal(AnimalViewModel model);
        AnimalViewModel UpdateById(string id);
        Task UpdateAnimal(AnimalViewModel model);
        List<AnimalViewModel> GetAll();
        Task SaveChangesAsync();
        AnimalViewModel GetDetailsById(string id);
        AnimalViewModel Find(string id);
        Task UpdateAsync(AnimalViewModel model);

	}
}
