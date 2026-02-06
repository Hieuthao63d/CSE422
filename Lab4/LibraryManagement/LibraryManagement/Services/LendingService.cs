using System;
using LibraryManagement.Interfaces;

namespace LibraryManagement.Services
{
    public class LendingService : ILendingService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMemberRepository _memberRepo;

        public LendingService(IBookRepository bookRepo, IMemberRepository memberRepo)
        {
            _bookRepo = bookRepo;
            _memberRepo = memberRepo;
        }

        public bool BorrowBook(string memberId, string bookId)
        {
            var member = _memberRepo.GetById(memberId);
            var book = _bookRepo.GetById(bookId);

            if (member == null || book == null)
            {
                Console.WriteLine("Error: Member or Book not found.");
                return false;
            }

            if (!member.CanBorrow())
            {
                Console.WriteLine($"Error: Member {member.Name} has reached the borrowing limit.");
                return false;
            }

            if (book.AvailableQuantity <= 0)
            {
                Console.WriteLine($"Error: Book '{book.Title}' is out of stock.");
                return false;
            }

            book.DecreaseStock();
            member.BorrowBook(book);
            Console.WriteLine($"Success: {member.Name} borrowed '{book.Title}'.");
            return true;
        }

        public void ReturnBook(string memberId, string bookId)
        {
            var member = _memberRepo.GetById(memberId);
            var book = member?.BorrowedBooks.Find(b => b.Id == bookId);

            if (member == null || book == null)
            {
                Console.WriteLine("Error: Member not found or Member does not possess this book.");
                return;
            }

            member.ReturnBook(book);
            book.IncreaseStock();
            Console.WriteLine($"Success: {member.Name} returned '{book.Title}'.");
        }
    }
}