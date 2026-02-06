using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public BookRepository()
        {
            _books = new List<Book>
            {
                new PhysicalBook("B001", "Clean Code", "Robert C. Martin", "Technology", 3),
                new PhysicalBook("B002", "The Pragmatic Programmer", "Andrew Hunt", "Technology", 2),
                new PhysicalBook("B003", "Harry Potter", "J.K. Rowling", "Fiction", 5),
                new PhysicalBook("B004", "The Clean Architect", "Robert C. Martin", "Technology", 4),
                new PhysicalBook("B005", "Design Patterns", "Erich Gamma", "Technology", 2),
                new PhysicalBook("B006", "Refactoring", "Martin Fowler", "Technology", 3),
                new PhysicalBook("B007", "Introduction to Algorithms", "Thomas H. Cormen", "Technology", 2),
                new PhysicalBook("B008", "The Great Gatsby", "F. Scott Fitzgerald", "Fiction", 6),
                new PhysicalBook("B009", "1984", "George Orwell", "Fiction", 4),
                new PhysicalBook("B010", "To Kill a Mockingbird", "Harper Lee", "Fiction", 5),
                new PhysicalBook("B011", "The Alchemist", "Paulo Coelho", "Fiction", 8),
                new PhysicalBook("B012", "Sapiens", "Yuval Noah Harari", "History", 4),
                new PhysicalBook("B013", "Thinking, Fast and Slow", "Daniel Kahneman", "Psychology", 3),
                new PhysicalBook("B014", "Atomic Habits", "James Clear", "Self-Help", 10),
                new PhysicalBook("B015", "The 7 Habits of Highly Effective People", "Stephen Covey", "Self-Help", 5),
                new PhysicalBook("B016", "Rich Dad Poor Dad", "Robert Kiyosaki", "Finance", 7),
                new PhysicalBook("B017", "Deep Work", "Cal Newport", "Self-Help", 4),
                new PhysicalBook("B018", "The Hobbit", "J.R.R. Tolkien", "Fiction", 6),
                new PhysicalBook("B019", "Start with Why", "Simon Sinek", "Business", 3),
                new PhysicalBook("B020", "Zero to One", "Peter Thiel", "Business", 4)
            };
        }

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        public Book GetById(string id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public List<Book> SearchByTitle(string title)
        {
            return _books.Where(b => b.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
    }
}