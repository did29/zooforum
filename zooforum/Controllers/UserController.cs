using Microsoft.AspNetCore.Mvc;
using zooforum.Data.DataModel;
using zooforum.Services;

namespace zooforum.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            
            var users = UserService.GetAllUsers();

            
            return View(users);
        }

        public ActionResult Details(int id)
        {
            var user = UserService.GetUserById(id);

            if (user == null)
            {
              
                return HttpNotFound();
            }

            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                UserService.AddUser(user);

                return RedirectToAction("Details", new { id = user.Id });
            }

            return View(user);
        }

        public ActionResult Edit(int id)
        {
            var user = UserService.GetUserById(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                UserService.UpdateUser(user);

                return RedirectToAction("Details", new { id = user.Id });
            }

            return View(user);
        }

        public ActionResult Delete(int id)
        {
            var user = UserService.GetUserById(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserService.DeleteUser(id);

            return RedirectToAction("Index");
        }
    }
}
