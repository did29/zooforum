using zooforum.Data;
using zooforum.Services.ViewModels;

namespace zooforum.Services
{
    public class AnimalService
    {
        private readonly ApplicationDbContext context;
        public AnimalService(ApplicationDbContext post)
        {
            context = post;
        }

        public List<AnimalViewModel> GetAll()
        {
            return context.Animal.Select(animal => new AnimalViewModel()
            {
                Id = animal.Id,
                Breed = animal.Breed,
               
            }).ToList();
        }
    }
}
