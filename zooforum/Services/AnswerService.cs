﻿using zooforum.Data.DataModel;
using zooforum.Data;
using zooforum.Services.Interfaces;
using zooforum.Services.ViewModels;

namespace zooforum.Services
{
    public class AnswerService : IAnswerService
    {
//        private readonly ApplicationDbContext context;
//        public AnswerService(ApplicationDbContext post)
//        {
//            context = post;
//        }

//        public List<AnswerViewModel> GetAll()
//        {
//            return context.Animal.Select(animal => new AnswerViewModel()
//            {
//                //Id = animal.Id,
//                //Type = animal.Type,
//                //Breed = animal.Breed

//            }).ToList();
//        }
//        public async Task CreateAsync(AnswerViewModel model)
//        {
//            Animal animal = new Animal();

//            animal.Id = Guid.NewGuid().ToString();
//            animal.Type = model.Type;
//            animal.Breed = model.Breed;

//            await context.Animal.AddAsync(animal);
//            await context.SaveChangesAsync();
//        }
//        public async Task DeleteAnimal(string id)
//        {
//            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
//            {
//                Console.WriteLine("Eror!");
//            }
//            if (id != null)
//            {
//                var animalDb = context.Animal.FirstOrDefault(x => x.Id == id);
//                context.Animal.Remove(animalDb);
//                await context.SaveChangesAsync();
//            }
//        }
//        public AnswerViewModel GetDetailsById(string id)
//        {
//            AnswerViewModel animal = context.Animal
//                .Select(animal => new AnswerViewModel
//                {
//                    Id = animal.Id,
//                    Type = animal.Type,
//                    Breed = animal.Breed,
//                }).SingleOrDefault(animal => animal.Id == id);

//            return animal;
//        }
//        public AnswerViewModel UpdateById(string id)
//        {
//            AnswerViewModel animal = context.Animal
//                .Select(animal => new AnswerViewModel
//                {
//                    Id = animal.Id,
//                    Type = animal.Type,
//                    Breed = animal.Breed,
//                }).SingleOrDefault(animal => animal.Id == id);

//            return animal;
//        }
//        public async Task UpdateAsync(AnswerViewModel model)
//        {
//            Animal animal = context.Animal.Find(model.Id);

//            bool isAnimalNull = animal == null;
//            if (isAnimalNull)
//            {
//                return;
//            }

//            context.Animal.Update(animal);
//            await context.SaveChangesAsync();
//        }
   }
}