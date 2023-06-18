using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zooforum.Data.DataModel;
using zooforum.Data;
using zooforum.Services;
using zooforum.Services.Interfaces;
using zooforum.Services.ViewModels;

namespace zooforum.Controllers
{
    public class QuestionController : Controller
    {

            public QuestionService questionService { get; set; }

            public QuestionController(QuestionService service)
            {
                questionService = service;
            }

            public ActionResult Index()
        {
            var questions = questionService.GetAll();
            return View(questions);
        }


        public ActionResult Details(string id)
        {
            var question = questionService.GetDetailsById(id);
            if (question == null)
            {
               return NotFound();
            }
            return View(question);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateQuestion(QuestionViewModel question)
        {
            if (ModelState.IsValid)
            {
                await questionService.CreateQuestion(question);
                await questionService.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(question);
        }


        public ActionResult Edit(string id)
        {
            var question = questionService.Find(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(QuestionViewModel question)
        {
            if (ModelState.IsValid)
            {
                await questionService.UpdateAsync(question);
                return RedirectToAction("Index");
            }
            return View(question);
        }


        public ActionResult DeleteQuestion(string id)
        {
            var question = questionService.DeleteQuestion(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var question = questionService.DeleteQuestion(id);
            questionService.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

