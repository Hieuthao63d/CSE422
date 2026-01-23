using Lab2.Models;
using Lab2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2.Controllers
{
    public class DeviceController : Controller
    {
        private readonly DeviceService _deviceService;
        private readonly DeviceCategoryService _categoryService;

        public DeviceController(DeviceService deviceService, DeviceCategoryService categoryService)
        {
            _deviceService = deviceService;
            _categoryService = categoryService;
        }

        public IActionResult Index(string searchString, int? categoryId, DeviceStatus? status)
        {
            var devices = _deviceService.GetAll(searchString, categoryId, status);

            
            foreach (var device in devices)
            {
                device.Category = _categoryService.GetById(device.CategoryId);
            }
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name", categoryId);
            ViewBag.CurrentSearch = searchString;
            ViewBag.CurrentStatus = status;

            return View(devices);
        }

        // 2. Create - GET
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name");
            return View();
        }

        // 2. Create - POST
        [HttpPost]
        public IActionResult Create(Device device)
        {
            if (ModelState.IsValid)
            {
                _deviceService.Add(device);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name", device.CategoryId);
            return View(device);
        }

        // 3. Edit - GET
        public IActionResult Edit(int id)
        {
            var device = _deviceService.GetById(id);
            if (device == null) return NotFound();

            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name", device.CategoryId);
            return View(device);
        }

        // 3. Edit - POST
        [HttpPost]
        public IActionResult Edit(Device device)
        {
            if (ModelState.IsValid)
            {
                _deviceService.Update(device);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name", device.CategoryId);
            return View(device);
        }

        // 4. Delete - GET
        public IActionResult Delete(int id)
        {
            var device = _deviceService.GetById(id);
            if (device == null) return NotFound();

            device.Category = _categoryService.GetById(device.CategoryId);

            return View(device);
        }

        // 4. Delete - POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _deviceService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}