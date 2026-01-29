using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Lab3
{
    public class ReturnTransaction : Transaction
    {
        public Book BookReturned { get; set; }

        public override void Execute()
        {
            BookReturned.CopiesAvailable++;
            Console.WriteLine($"{Member.Name} has returned '{BookReturned.Title}'.");
        }
    }
}
