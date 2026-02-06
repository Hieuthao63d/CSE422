namespace LibraryManagement.Models
{
    public class PhysicalBook : Book
    {
        public PhysicalBook(string id, string title, string author, string category, int quantity)
            : base(id, title, author, category, quantity)
        {
        }
    }
}