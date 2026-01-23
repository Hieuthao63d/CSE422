using Lab2.Models;

namespace Lab2.Services
{
    public class DeviceCategoryService
    {
        private readonly List<DeviceCategory> _categories;

        public DeviceCategoryService()
        {
            // Mock Data (Dữ liệu giả lập)
            _categories = new List<DeviceCategory>
            {
                new DeviceCategory { Id = 1, Name = "Laptop", Description = "Portable computers" },
                new DeviceCategory { Id = 2, Name = "Monitor", Description = "Display screens" },
                new DeviceCategory { Id = 3, Name = "Printer", Description = "Office printers" },
                new DeviceCategory { Id = 4, Name = "Phone", Description = "Mobile devices" }
            };
        }

        public List<DeviceCategory> GetAll()
        {
            return _categories;
        }

        public DeviceCategory? GetById(int id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }

        public void Add(DeviceCategory category)
        {
            // Tự động tăng ID
            category.Id = _categories.Any() ? _categories.Max(c => c.Id) + 1 : 1;
            _categories.Add(category);
        }

        public void Update(DeviceCategory category)
        {
            var existing = GetById(category.Id);
            if (existing != null)
            {
                existing.Name = category.Name;
                existing.Description = category.Description;
            }
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}