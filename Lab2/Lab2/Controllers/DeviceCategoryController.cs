using Lab2.Models;
using Lab2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class DeviceCategoryController : Controller
    {
        private readonly DeviceCategoryService _service;

        // Constructor Injection: Gọi Service đã đăng ký ở Program.cs
        public DeviceCategoryController(DeviceCategoryService service)
        {
            _service = service;
        }

        // 1. Xem danh sách (Index)
        public IActionResult Index()
        {
            var list = _service.GetAll();
            return View(list);
        }

        // 2. Tạo mới (Create) - GET: Hiển thị form
        public IActionResult Create()
        {
            return View();
        }

        // 2. Tạo mới (Create) - POST: Xử lý dữ liệu gửi lên
        [HttpPost]
        public IActionResult Create(DeviceCategory category)
        {
            if (ModelState.IsValid)
            {
                _service.Add(category);
                return RedirectToAction("Index");
            }
            return View(category); // Nếu lỗi validation thì trả lại form cũ kèm thông báo lỗi
        }

        // 3. Chỉnh sửa (Edit) - GET
        public IActionResult Edit(int id)
        {
            var category = _service.GetById(id);
            if (category == null) return NotFound();
            return View(category);
        }

        // 3. Chỉnh sửa (Edit) - POST
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

        // 4. Xóa (Delete) - GET: Hỏi xác nhận xóa
        public IActionResult Delete(int id)
        {
            var category = _service.GetById(id);
            if (category == null) return NotFound();
            return View(category);
        }

        // 4. Xóa (Delete) - POST: Thực hiện xóa
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}