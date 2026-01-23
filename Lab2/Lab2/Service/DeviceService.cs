using Lab2.Models;

namespace Lab2.Services
{
    public class DeviceService
    {
        private readonly List<Device> _devices;

        public DeviceService()
        {
            _devices = new List<Device>
            {
                new Device { Id = 1, Name = "Dell XPS 13", Code = "LAP-001", CategoryId = 1, Status = DeviceStatus.InUse, DateOfEntry = DateTime.Now.AddMonths(-5) },
                new Device { Id = 2, Name = "HP LaserJet", Code = "PRT-002", CategoryId = 3, Status = DeviceStatus.Broken, DateOfEntry = DateTime.Now.AddYears(-1) },
                new Device { Id = 3, Name = "iPhone 13", Code = "PHN-003", CategoryId = 4, Status = DeviceStatus.UnderMaintenance, DateOfEntry = DateTime.Now.AddMonths(-2) }
            };
        }

        public List<Device> GetAll(string? search = null, int? categoryId = null, DeviceStatus? status = null)
        {
            var result = _devices.AsQueryable();

            // Search by Name or Code
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                result = result.Where(d => d.Name.ToLower().Contains(search) || d.Code.ToLower().Contains(search));
            }

            // Filter by Category
            if (categoryId.HasValue)
            {
                result = result.Where(d => d.CategoryId == categoryId.Value);
            }

            // Filter by Status
            if (status.HasValue)
            {
                result = result.Where(d => d.Status == status.Value);
            }

            return result.ToList();
        }

        public Device? GetById(int id)
        {
            return _devices.FirstOrDefault(d => d.Id == id);
        }

        public void Add(Device device)
        {
            device.Id = _devices.Any() ? _devices.Max(d => d.Id) + 1 : 1;
            _devices.Add(device);
        }

        public void Update(Device device)
        {
            var existing = GetById(device.Id);
            if (existing != null)
            {
                existing.Name = device.Name;
                existing.Code = device.Code;
                existing.CategoryId = device.CategoryId;
                existing.Status = device.Status;
                existing.DateOfEntry = device.DateOfEntry;
            }
        }

        public void Delete(int id)
        {
            var device = GetById(id);
            if (device != null)
            {
                _devices.Remove(device);
            }
        }
    }
}