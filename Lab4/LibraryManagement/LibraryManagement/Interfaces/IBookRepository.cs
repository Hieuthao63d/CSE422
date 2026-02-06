using System.Collections.Generic;
using LibraryManagement.Models;

namespace LibraryManagement.Interfaces
{
    public interface IBookRepository
    {
        void Add(Book book);
        Book GetById(string id);
        List<Book> SearchByTitle(string title);
        List<Book> GetAll();
    }
}