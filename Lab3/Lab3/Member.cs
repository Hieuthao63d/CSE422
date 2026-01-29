using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Lab3
{
    public class Member : IPrintable, IMemberActions
    {
        public string MemberID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"MemberID: {MemberID}, Name: {Name}, Email: {Email}");
        }

        public virtual void BorrowBook(Book book)
        {
            if (book.CopiesAvailable > 0)
            {
                book.CopiesAvailable--;
                Console.WriteLine($"{Name} borrowed '{book.Title}'.");
            }
            else
            {
                Console.WriteLine($"No copies available for '{book.Title}'.");
            }
        }

        public virtual void ReturnBook(Book book)
        {
            book.CopiesAvailable++;
            Console.WriteLine($"{Name} returned '{book.Title}'.");
        }

        public void PrintDetails()
        {
            throw new NotImplementedException();
        }
    }
}
