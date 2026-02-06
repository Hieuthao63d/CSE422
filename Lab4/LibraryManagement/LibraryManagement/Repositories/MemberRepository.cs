using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly List<Member> _members;

        public MemberRepository()
        {
            _members = new List<Member>
            {
                new Member("M001", "Nguyen Van Binh"),
                new Member("M002", "Tran Thi Thuy"),
                new Member("M003", "Le Van Cuong"),
                new Member("M004", "Pham Thanh Thao"),
                new Member("M005", "Hoang Minh Triet"),
                new Member("M006", "Dang Thu Ha"),
                new Member("M007", "Ngo Bao Chau"),
                new Member("M008", "Vu Hoang Yen"),
                new Member("M009", "Do Huu Long"),
                new Member("M010", "Bui Bich Phuong"),
                new Member("M011", "Ly Gia Han"),
                new Member("M012", "Trinh Xuan Bach")
            };
        }

        public void Add(Member member)
        {
            _members.Add(member);
        }

        public List<Member> GetAll()
        {
            return _members;
        }

        public Member GetById(string id)
        {
            return _members.FirstOrDefault(m => m.Id == id);
        }
    }
}