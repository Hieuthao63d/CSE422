using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Lab3
{
    public class BorrowTransaction : Transaction
    {
        public Book BookBorrowed { get; set; }

        public override void Execute()
        {
            if (BookBorrowed.CopiesAvailable > 0)
            {
                BookBorrowed.CopiesAvailable--;
                Console.WriteLine($"{Member.Name} has borrowed '{BookBorrowed.Title}'.");
            }
            else
            {
                Console.WriteLine($"No copies available for '{BookBorrowed.Title}'.");
            }
        }
    }
}
