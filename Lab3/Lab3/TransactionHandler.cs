using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class TransactionHandler
    {
        public void HandleTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();

            Member member1 = new Member { MemberID = "M001", Name = "Alice", Email = "alice@example.com" };
            Book book1 = new Book { ISBN = "ISBN001", Title = "C# Programming", Author = "Author A", Year = 2020, CopiesAvailable = 5 };

            BorrowTransaction borrow1 = new BorrowTransaction
            {
                TransactionID = "T001",
                TransactionDate = DateTime.Now,
                Member = member1,
                BookBorrowed = book1
            };

            ReturnTransaction return1 = new ReturnTransaction
            {
                TransactionID = "T002",
                TransactionDate = DateTime.Now,
                Member = member1,
                BookReturned = book1
            };
            //Transaction extra = new BorrowTransaction();
            //transactions.Add(extra);
            transactions.Add(borrow1);
            transactions.Add(return1);

            foreach (var transaction in transactions)
            {
                transaction.Execute();
            }
        }
    }
}
