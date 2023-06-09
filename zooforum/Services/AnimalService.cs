﻿using Microsoft.EntityFrameworkCore;
using zooforum.Data;
using zooforum.Data.DataModel;
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
                Breed = animal.Breed,
                Info = animal.Info,
                History = animal.History

            }).ToList();
        }
        public async Task CreateAnimal(AnimalViewModel model)
        {
            Animal animal = new Animal();

            animal.Id = Guid.NewGuid().ToString();
            animal.Type = model.Type;
            animal.Breed = model.Breed;
            animal.Info = model.Info;
            animal.History = model.History;

            await context.Animal.AddAsync(animal);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAnimal(AnimalViewModel model)
        {
            var animal = await context.Animal.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (animal != null)
            {
                animal.Type = model.Type;
                animal.Breed = model.Breed;
                animal.Info = model.Info;
                animal.History = model.History;

                await context.SaveChangesAsync();
            }
        }
        public async Task SaveChangesAsync()
        {
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
                var animalDb = context.Animal.FirstOrDefault(x => x.Id == id);
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
                    Info = animal.Info,
                    History = animal.History
                }).SingleOrDefault(animal => animal.Id == id);

            return animal;
        }
        public AnimalViewModel Find(string id)
        {
            var animal = context.Animal.FirstOrDefault(x => x.Id == id);
            var animalViewModel = new AnimalViewModel()
            {
                Id = animal.Id,
                Type = animal.Type,
                Breed = animal.Breed,
                Info = animal.Info,
                History = animal.History
            };

            return animalViewModel;
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
