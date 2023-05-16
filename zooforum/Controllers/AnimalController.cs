using Microsoft.AspNetCore.Mvc;

namespace zooforum.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
