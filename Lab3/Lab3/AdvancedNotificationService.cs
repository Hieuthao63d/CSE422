using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class AdvancedNotificationService : NotificationService
    {
        public override void SendNotification(string message)
        {
            Console.WriteLine($"[{DateTime.Now}] Advanced Notification: {message}");
        }
    }
}
