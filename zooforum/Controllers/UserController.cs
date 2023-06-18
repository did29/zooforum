using Microsoft.AspNetCore.Mvc;
using zooforum.Data.DataModel;
using zooforum.Services;
using zooforum.Services.Interfaces;
using zooforum.Services.ViewModels;

namespace zooforum.Controllers
{
    public class UserController : Controller
    {
        public UserService userService { get; set; }

        public UserController(UserService service)
        {
            userService = service;
        }
        public ActionResult Details(string id)
        {
            var user = userService.GetUserById(id);

            if (user == null)
            {

                return NotFound();
            }

            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                userService.AddUser(user);

                return RedirectToAction("Details", new { id = user.Id });
            }

            return View(user);
        }

        public ActionResult Edit(string id)
        {
            var user = userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                await userService.UpdateAsync(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult DeleteUser(string id)
        {
            var user = userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            userService.DeleteUser(id);

            return RedirectToAction("Index");
        }
    }
}
