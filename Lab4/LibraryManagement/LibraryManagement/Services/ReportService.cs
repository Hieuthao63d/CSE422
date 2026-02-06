using System;
using LibraryManagement.Interfaces;

namespace LibraryManagement.Services
{
    public class ReportService : IReportService
    {
        private readonly IMemberRepository _memberRepo;

        public ReportService(IMemberRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public void GenerateBorrowingReport()
        {
            Console.WriteLine("\nBORROWING REPORT");
            var members = _memberRepo.GetAll();

            foreach (var member in members)
            {
                Console.WriteLine($"Member: {member.Name} (ID: {member.Id})");
                if (member.BorrowedBooks.Count == 0)
                {
                    Console.WriteLine("  - No books borrowed.");
                }
                else
                {
                    foreach (var book in member.BorrowedBooks)
                    {
                        Console.WriteLine($"  - Borrowed: {book.Title} [ID: {book.Id}]");
                    }
                }
            }
        }
    }
}