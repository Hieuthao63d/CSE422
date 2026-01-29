using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Library
    {
        public string LibraryName { get; set; }
        public List<Book> Books { get; set; }
        public List<Member> Members { get; set; }

        // Event khi mượn sách
        public event Action<Book, Member> OnBookBorrowed;

        public Library(string libraryName)
        {
            LibraryName = libraryName;
            Books = new List<Book>();
            Members = new List<Member>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void AddMember(Member member)
        {
            Members.Add(member);
        }


        public void BorrowBook(string isbn, string memberId)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);
            var member = Members.FirstOrDefault(m => m.MemberID == memberId);
            //if (book.CopiesAvailable > 0 && member != null)
            //{
            //    member.BorrowBook(book);
            //}
            if (book != null && member != null && book.CopiesAvailable > 0)
            {
                member.BorrowBook(book);
                OnBookBorrowed?.Invoke(book, member);
            }
            else
            {
                Console.WriteLine("Cannot borrow the book.");
            }
        }
        public Library()
        {
            LibraryName = "Default Library";
            Books = new List<Book>();
            Members = new List<Member>();
        }
        public Library(Library otherLibrary)
        {
            LibraryName = otherLibrary.LibraryName + " (Copy)";
            // Tạo list mới để tránh tham chiếu trỏ về list cũ
            Books = new List<Book>(otherLibrary.Books);
            Members = new List<Member>(otherLibrary.Members);
        }
        public void DisplayLibraryInfo()
        {
            Console.WriteLine($"Library: {LibraryName}");
            Console.WriteLine($"Total Books: {Books.Count}");
            Console.WriteLine($"Total Members: {Members.Count}");
        }
        public void ReturnBook(string isbn, string memberId)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);
            var member = Members.FirstOrDefault(m => m.MemberID == memberId);

            if (book != null && member != null)
            {
                member.ReturnBook(book);
            }
            else
            {
                Console.WriteLine("Cannot return the book.");
            }
        }
    }

}
