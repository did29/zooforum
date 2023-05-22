﻿using zooforum.Data;
using zooforum.Services.Interfaces;
using zooforum.Services.ViewModels;

namespace zooforum.Services
{
    public class AnimalService : IAnimalService
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
                Type = animal.Type,
                Breed = animal.Breed

            }).ToList();
        }
        public async Task CreateAsync(AnimalViewModel model)
        {
            Animal movie = new Animal();

            movie.Id = Guid.NewGuid().ToString();
            movie.Type = model.Type;
            movie.Breed = model.Breed;

            await context.Animal.AddAsync(movie);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAnimal(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Eror!");
            }
            if (id != null)
            {
                var movieDb = context.Animal.FirstOrDefault(x => x.Id == id);
                context.Animal.Remove(animalDb);
                await context.SaveChangesAsync();
            }
        }
        public AnimalViewModel GetDetailsById(string id)
        {
            AnimalViewModel animal = context.Animal
                .Select(animal => new AnimalViewModel
                {
                    Id = animal.Id,
                    Type = animal.Type,
                    Breed = animal.Breed,
                }).SingleOrDefault(animal => animal.Id == id);

            return animal;
        }
        public AnimalViewModel UpdateById(string id)
        {
            AnimalViewModel animal = context.Animal
                .Select(animal => new AnimalViewModel
                {
                    Id = animal.Id,
                    Type = animal.Type,
                    Breed = animal.Breed,
                }).SingleOrDefault(animal => animal.Id == id);

            return animal;
        }
        public async Task UpdateAsync(AnimalViewModel model)
        {
            Animal animal = context.Animal.Find(model.Id);

            bool isAnimalNull = animal == null;
            if (isAnimalNull)
            {
                return;
            }

            context.Animal.Update(animal);
            await context.SaveChangesAsync();
        }
    }
}
