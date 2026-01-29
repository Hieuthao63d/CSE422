using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class NotificationServiceHandler
    {
        public void SendBorrowNotification(Book book, Member member)
        {
            Console.WriteLine($"Notification: {member.Name} has borrowed '{book.Title}'.");
        }

        public void LogBorrowActivity(Book book, Member member)
        {
            Console.WriteLine($"Log: {member.Name} borrowed '{book.Title}' on {DateTime.Now}.");
        }
    }
}
