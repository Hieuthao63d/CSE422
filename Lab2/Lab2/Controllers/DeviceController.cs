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

        // Inject c? 2 service vào
        public DeviceController(DeviceService deviceService, DeviceCategoryService categoryService)
        {
            _deviceService = deviceService;
            _categoryService = categoryService;
        }

        // 1. Index: Nh?n tham s? tìm ki?m và l?c t? View g?i lên
        public IActionResult Index(string searchString, int? categoryId, DeviceStatus? status)
        {
            // L?y d? li?u ?ã l?c t? Service
            var devices = _deviceService.GetAll(searchString, categoryId, status);

            // K? THU?T MOCK DATA: "Manual Join"
            // Vì không có Database th?t ?? t? Join, ta ph?i gán Category cho t?ng Device th? công
            // ?? hi?n th? tên lo?i thi?t b? ra màn hình thay vì ch? hi?n ID.
            foreach (var device in devices)
            {
                device.Category = _categoryService.GetById(device.CategoryId);
            }

            // Chu?n b? d? li?u cho Dropdown l?c ? View
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name", categoryId);
            ViewBag.CurrentSearch = searchString;
            ViewBag.CurrentStatus = status;

            return View(devices);
        }

        // 2. Create - GET
        public IActionResult Create()
        {
            // ?? d? li?u Categories vào ViewBag ?? t?o Dropdown ch?n
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name");
            return View();
        }

        // 2. Create - POST
        [HttpPost]
        public IActionResult Create(Device device)
        {
            // Ki?m tra Validation
            if (ModelState.IsValid)
            {
                _deviceService.Add(device);
                return RedirectToAction("Index");
            }

            // N?u l?i, n?p l?i Dropdown ?? không b? m?t d? li?u
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name", device.CategoryId);
            return View(device);
        }

        // 3. Edit - GET
        public IActionResult Edit(int id)
        {
            var device = _deviceService.GetById(id);
            if (device == null) return NotFound();

            // Ch?n s?n Category hi?n t?i c?a Device
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

            // Gán category ?? hi?n th? tên lúc h?i xóa
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