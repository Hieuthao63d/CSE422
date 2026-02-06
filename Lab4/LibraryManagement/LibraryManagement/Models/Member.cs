using System.Collections.Generic;

namespace LibraryManagement.Models
{
    public class Member
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<Book> BorrowedBooks { get; private set; }

        public Member(string id, string name)
        {
            Id = id;
            Name = name;
            BorrowedBooks = new List<Book>();
        }

        public bool CanBorrow()
        {
            return BorrowedBooks.Count < 3;
        }

        public void BorrowBook(Book book)
        {
            BorrowedBooks.Add(book);
        }

        public void ReturnBook(Book book)
        {
            BorrowedBooks.Remove(book);
        }
    }
}