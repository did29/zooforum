using Microsoft.AspNetCore.Mvc;

namespace zooforum.Controllers
{
    public class AnswerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
