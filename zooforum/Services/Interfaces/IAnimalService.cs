namespace zooforum.Services.Interfaces
{
    public interface IAnimalService
    {
        Task DeleteAnimal(string id);
        Task CreateAsync(AnimalViewModel model);
        AnimalViewModel UpdateById(string id);
        Task UpdateAsync(AnimalViewModel model);
    }
}
