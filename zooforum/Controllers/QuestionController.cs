using Microsoft.AspNetCore.Mvc;

namespace zooforum.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
