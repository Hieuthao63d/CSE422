using System;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using LibraryManagement.Repositories;
using LibraryManagement.Services;

namespace LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LIBRARY MANAGEMENT SYSTEM\n");

            IBookRepository bookRepo = new BookRepository();
            IMemberRepository memberRepo = new MemberRepository();

            ILendingService lendingService = new LendingService(bookRepo, memberRepo);
            IReportService reportService = new ReportService(memberRepo);

            //show booklist
            Console.WriteLine("Initial book list");
            foreach (var book in bookRepo.GetAll())
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();

            //Mượn sách 
            Console.WriteLine("Borrowing operation");

            //Mượn thành công
            Console.WriteLine("\n borrowing:");
            lendingService.BorrowBook("M001", "B001");

            // Mượn thất bại do hết sách 
            Console.WriteLine("\nFail due to out of stock (B002 has 2 copies):");

            lendingService.BorrowBook("M001", "B002");

            lendingService.BorrowBook("M002", "B002");

            Console.Write("Attempting to borrow the 3rd copy of B002: ");
            lendingService.BorrowBook("M001", "B002");


            // Mượn thất bại do quá giưới hạn
            Console.WriteLine("\nFail due to borrowing limit (Max 3 books/member):");

            lendingService.BorrowBook("M001", "B003");

            Console.Write("M001 attempt to borrow the 4th book: ");
            lendingService.BorrowBook("M001", "B001");
            Console.WriteLine();

            //Trả sách
            Console.WriteLine("Returning operation");
            lendingService.ReturnBook("M001", "B002");
            Console.WriteLine();

            reportService.GenerateBorrowingReport();

            Console.WriteLine("Search book (keyword: 'Harry')");
            var searchResults = bookRepo.SearchByTitle("Harry");
            foreach (var item in searchResults)
            {
                Console.WriteLine(item);
            }

            //Admin add book
            Console.WriteLine("\nAdmin adding new book");
            Book newBook1 = new PhysicalBook("B021", "The Alchemist", "Paulo Coelho", "Fiction", 10);
            Book newBook2 = new PhysicalBook("B022", "Refactoring", "Martin Fowler", "Technology", 5);
            Book newBook3 = new PhysicalBook("B023", "Algorithms", "Thomas H. Cormen", "Education", 2);

            bookRepo.Add(newBook1);
            bookRepo.Add(newBook2);
            bookRepo.Add(newBook3);

            Console.WriteLine("Admin has successfully added 3 book");
            Console.WriteLine("\nUpdated Book List");
            foreach (var book in bookRepo.GetAll())
            {
                Console.WriteLine(book);
            }
        }
    }
}