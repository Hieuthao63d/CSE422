using Lab2.Models;

namespace Lab2.Services
{
    public class UserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User>
            {
                new User { Id = 1, FullName = "Nguyen Van A", Email = "a.nguyen@example.com", PhoneNumber = "0901234567" },
                new User { Id = 2, FullName = "Tran Thi B", Email = "b.tran@example.com", PhoneNumber = "0909876543" }
            };
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public User? GetById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public void Add(User user)
        {
            user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(user);
        }

        public void Update(User user)
        {
            var existing = GetById(user.Id);
            if (existing != null)
            {
                existing.FullName = user.FullName;
                existing.Email = user.Email;
                existing.PhoneNumber = user.PhoneNumber;
            }
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}