using Lab2.Models;
using Lab2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class DeviceCategoryController : Controller
    {
        private readonly DeviceCategoryService _service;

        public DeviceCategoryController(DeviceCategoryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var list = _service.GetAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DeviceCategory category)
        {
            if (ModelState.IsValid)
            {
                _service.Add(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var category = _service.GetById(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(DeviceCategory category)
        {
            if (ModelState.IsValid)
            {
                _service.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = _service.GetById(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}