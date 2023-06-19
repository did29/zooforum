using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zooforum.Data.DataModel;
using zooforum.Data;
using zooforum.Services;
using zooforum.Services.ViewModels;
using zooforum.Services.Interfaces;

namespace zooforum.Controllers
{
    public class AnimalController : Controller
    {
        private readonly DogApiClient _dogApiClient;
        private const string ApiKey = "live_facp0Z1QxYUgk18rlw5tYEMzZfvPWVkgTa27FZKs89l6beF6edNsglX5TugU8LJV";

        public AnimalController()
        {
            _dogApiClient = new DogApiClient();
        }

        public async Task<ActionResult> RandomDogImage()
        {
            string imageUrl = await _dogApiClient.GetRandomDogImageAsync(ApiKey);

            // Pass the image URL to the view
            ViewBag.ImageUrl = imageUrl;

            return View();
        }

        public AnimalController()
        {
            _dogApiClient = new DogApiClient();
        }

        public async Task<ActionResult> RandomDogImage()
        {
            string imageUrl = await _dogApiClient.GetRandomDogImageAsync();

            
            ViewBag.ImageUrl = imageUrl;

            return View();
        }
        public IAnimalService animalService { get; set; }

        public AnimalController(IAnimalService service)
        {
            animalService = service;
        }
        public IActionResult Index()
        {
            var animals = animalService.GetAll();
            return View(animals);
        }


        public ActionResult Details(string id)
        {
            var animal = animalService.GetDetailsById(id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAnimal(AnimalViewModel animal)
        {
            if (ModelState.IsValid)
            {
                animalService.CreateAnimal(animal);
                return RedirectToAction("Index");
            }
            return View(animal);
        }


        public ActionResult Edit(string id)
        {
            var animal = animalService.Find(id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AnimalViewModel animal)
        {
            if (ModelState.IsValid)
            {
                await animalService.UpdateAsync(animal);
                return RedirectToAction("Index");
            }
            return View(animal);
        }


        public ActionResult Delete(string id)
        {
            var animal = animalService.Find(id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await animalService.DeleteAnimal(id);
            animalService.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

