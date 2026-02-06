using System.Collections.Generic;
using LibraryManagement.Models;

namespace LibraryManagement.Interfaces
{
    public interface IMemberRepository
    {
        void Add(Member member);
        Member GetById(string id);
        List<Member> GetAll();
    }
}