using System;

namespace LibraryManagement.Models
{
    public abstract class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int TotalQuantity { get; set; }
        public int AvailableQuantity { get; set; } 

        public Book(string id, string title, string author, string category, int quantity)
        {
            Id = id;
            Title = title;
            Author = author;
            Category = category;
            TotalQuantity = quantity;
            AvailableQuantity = quantity;
        }

        public bool DecreaseStock()
        {
            if (AvailableQuantity > 0)
            {
                AvailableQuantity--;
                return true;
            }
            return false;
        }

        public void IncreaseStock()
        {
            if (AvailableQuantity < TotalQuantity)
            {
                AvailableQuantity++;
            }
        }

        public override string ToString()
        {
            return $"[ID: {Id}] {Title} - {Author} ({Category}) | stock : {AvailableQuantity/TotalQuantity}";
        }
    }
}