using Microsoft.AspNetCore.Mvc;

namespace zooforum.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
