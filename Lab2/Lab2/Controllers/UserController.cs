using Lab2.Models;
using Lab2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View(_userService.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}