
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // EXERCISE 1
            //Tạo đối tượng sách
            // Kiểm tra tính đóng gói qua thuộc tính Year, CopiesAvailable
            Console.WriteLine("Exercise 1:");
            Book book1 = new Book { ISBN = "ISBN001", Title = "C# Programming", Author = "Author A", Year = 2020, CopiesAvailable = 5 };
            Book book2 = new Book { ISBN = "ISBN002", Title = "OOP Concepts", Author = "Author B", Year = 2018, CopiesAvailable = 2 };

            // Gọi phương thức DisplayInfo() của class Book
            book1.DisplayInfo();
            book2.DisplayInfo();
            Console.WriteLine();


            // EXERCISE 2
            // Tạo Member thường
            // Tạo PremiumMember kế thừa từ Member
            Console.WriteLine("Exercise 2:");
            Member member1 = new Member { MemberID = "M001", Name = "Alice", Email = "alice@example.com" };

            PremiumMember member2 = new PremiumMember
            {
                MemberID = "M002",
                Name = "Bob",
                Email = "bob@example.com",
                MembershipExpiry = DateTime.Now.AddYears(1),
                MaxBooksAllowed = 10
            };

            // Hiển thị thông tin để kiểm tra method DisplayInfo() được kế thừa/ghi đè
            member1.DisplayInfo();
            member2.DisplayInfo();
            Console.WriteLine();


            // EXERCISE 3
            // tạo các giao dịch BorrowTransaction và ReturnTransaction từ lớp trừu tượng Transaction
            Console.WriteLine("Exercise 3");

            BorrowTransaction borrowTrans = new BorrowTransaction
            {
                TransactionID = "T001",
                TransactionDate = DateTime.Now,
                Member = member1,
                BookBorrowed = book1
            };

            ReturnTransaction returnTrans = new ReturnTransaction
            {
                TransactionID = "T002",
                TransactionDate = DateTime.Now.AddDays(7),
                Member = member1,
                BookReturned = book1
            };
            Console.WriteLine("Transaction objects initialized.");
            Console.WriteLine();


            // EXERCISE 4: 
            // Tạo List<Transaction>
            //duyệt vòng lặp và gọi hàm Execute() (Đa hình)
            Console.WriteLine("Exercise 4:");
            List<Transaction> transactions = new List<Transaction>();
            transactions.Add(borrowTrans);
            transactions.Add(returnTrans);

            foreach (var trans in transactions)
            {
                // Gọi method Execute() của lớp con tương ứng
                trans.Execute();
            }
            Console.WriteLine();


            // EXERCISE 5
            // kiểm tra Interface IPrintable (PrintDetails)
            // kiểm tra Interface IMemberActions 
            Console.WriteLine("Exercise 5:");

            // 1 Test IPrintable
            Console.Write("Testing IPrintable on Book: ");
            ((IPrintable)book1).PrintDetails();

            // 2 Test IMemberActions 
            Console.WriteLine("Testing IMemberActions on Member:");
            member1.BorrowBook(book2); // Alice mượn cuốn OOP Concepts
            Console.WriteLine();


            // EXERCISE 6
            //Khởi tạo thư viện dùng các Constructor khác nhau
            // Thêm sách và thành viên đã tạo ở Ex1, Ex2 vào thư viện
            Console.WriteLine("Exercise 6:");

            // Sử dụng Parameterized Constructor
            Library library = new Library("Eastern International University Library");

            // Thêm dữ liệu vào thư viện
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddMember(member1);
            library.AddMember(member2);

            // Hiển thị thông tin thư viện
            library.DisplayLibraryInfo();
            Console.WriteLine();


            // EXERCISE 7
 
            Console.WriteLine("Exercise 7:");
            NotificationService basicService = new NotificationService();
            AdvancedNotificationService advancedService = new AdvancedNotificationService();

            // Test Overloading
            basicService.SendNotification("Hello Library!");
            basicService.SendNotification("Please return books on time.", "Alice");
            basicService.SendNotification("New arrivals available.", new List<string> { "Alice", "Bob" });

            // Test Overriding
            advancedService.SendNotification("Server maintenance at midnight."); 
            Console.WriteLine();


            // EXERCISE 8
            // - Tạo thẻ thư viện và thử phương thức RenewCard
            Console.WriteLine("Exercise 8:");
            LibraryCard card = new LibraryCard("CARD-001", member1);

            card.PrintCardDetails(); // Ngày cấp là hiện tại
            card.RenewCard();        // Cập nhật ngày cấp
            Console.WriteLine("After renewal:");
            card.PrintCardDetails();
            Console.WriteLine();


            // EXERCISE 9
            // So sánh toán tử == giữa Class và Record
            //  Thử tính năng 'with' của Record
            Console.WriteLine("Exercise 9:");
            BookClass c1 = new BookClass("111", "Book A", "Author X");
            BookClass c2 = new BookClass("111", "Book A", "Author X");

            BookRecord r1 = new BookRecord("111", "Book A", "Author X");
            BookRecord r2 = new BookRecord("111", "Book A", "Author X");

            Console.WriteLine($"Class comparison (==): {c1 == c2}"); 
            Console.WriteLine($"Record comparison (==): {r1 == r2}");

            var r3 = r1 with { Title = "Book A - 2nd Edition" };
            Console.WriteLine($"Original Record: {r1}");
            Console.WriteLine($"Copied Record (with): {r3}");
            Console.WriteLine();


            // EXERCISE 10: Delegates and Events [cite: 122-128]
            Console.WriteLine("Exercise 10: Delegates and Events");

            NotificationServiceHandler handler = new NotificationServiceHandler();

            //  Đăng ký các method vào Event của Library
            library.OnBookBorrowed += handler.SendBorrowNotification;
            library.OnBookBorrowed += handler.LogBorrowActivity;
            Console.WriteLine("(Events subscribed successfully)");

            //  Kích hoạt sự kiện bằng cách mượn sách thông qua Library
            Console.WriteLine("Action: Bob borrows 'C# Programming'...");
            library.BorrowBook("ISBN001", "M002");

            Console.ReadLine();
        }
    }
}