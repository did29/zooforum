using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zooforum.Data.DataModel;
using zooforum.Services;
using zooforum.Services.ViewModels;

namespace zooforum.Controllers
{
    public class AnswerController : Controller
    { 

    public AnswerService answerService { get; set; }

    public AnswerController(AnswerService service)
    {
        answerService = service;
    }


    public ActionResult Index()
    {
        var answers = answerService.GetAll;
        return View(answers);
    }


    public ActionResult Details(string id)
    {
        var answer = answerService.GetDetailsById(id);
        if (answer == null)
        {
            return NotFound();
        }
        return View(answer);
    }

    public ActionResult CreateAnswer()
    {
        return View();
    }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAnswer(AnswerViewModel answer)
        {
            if (ModelState.IsValid)
            {
                await answerService.CreateAnswer(answer);
                await answerService.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(answer);
        }

        public ActionResult Edit(string id)
    {
        var answer = answerService.Find(id);
        if (answer == null)
        {
            return NotFound();
        }
        return View(answer);
    }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AnswerViewModel answer)
        {
            if (ModelState.IsValid)
            {
                await answerService.UpdateAsync(answer);
                return RedirectToAction("Index");
            }
            return View(answer);
        }

        public ActionResult DeleteAnswer(string id)
    {
        var answer = answerService.DeleteAnswer(id);
        if (answer == null)
        {
            return NotFound();
        }
        return View(answer);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await answerService.DeleteAnswer(id); 
            answerService.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        
    }
}

