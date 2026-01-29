

namespace Lab3
{
    public class PremiumMember : Member
    {
        public DateTime MembershipExpiry { get; set; }
        public int MaxBooksAllowed { get; set; }

        //public override void BorrowBook(Book book)
        //{
        //    if (DateTime.Now > MembershipExpiry)
        //    {
        //        Console.WriteLine($"{Name} (Premium) membership expired.");
        //        return;
        //    }

        //    if (book.CopiesAvailable > 0 && MaxBooksAllowed > 0)
        //    {
        //        book.CopiesAvailable--;
        //        MaxBooksAllowed--;
        //        Console.WriteLine($"{Name} (Premium) borrowed '{book.Title}'.");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Cannot borrow '{book.Title}' due to restrictions.");
        //    }
        //}
        public override void BorrowBook(Book book)
        {
            if (book.CopiesAvailable > 0 && MaxBooksAllowed > 0)
            {
                book.CopiesAvailable--;
                MaxBooksAllowed--;
                Console.WriteLine($"{Name} (Premium) borrowed '{book.Title}'.");
            }
            else
            {
                Console.WriteLine($"Cannot borrow '{book.Title}'.");
            }
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Membership Expiry: {MembershipExpiry.ToShortDateString()}, Max Books Allowed: {MaxBooksAllowed}");
        }
    }
}

