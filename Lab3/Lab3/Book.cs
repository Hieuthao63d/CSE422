using System;

namespace Lab3
{
    public class Book : IPrintable
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        //public int Year
        //{
        //    get
        //    {
        //        return this.Year;
        //    }
        //    set
        //    {
        //        if (value >= 0)
        //        {
        //            Year = value;
        //        }
        //    }

        //}
        //public int CopiesAvailable
        //{
        //    get
        //    {
        //        return this.CopiesAvailable;
        //    }
        //    set
        //    {
        //        if (value >= 0)
        //        {
        //            CopiesAvailable = value;
        //        }
        //    }
        //}
        private int year;
        public int Year
        {
            get { return year; }
            set { year = value >= 0 ? value : 0; }
        }
        private int copiesAvailable;
        public int CopiesAvailable
        {
            get { return copiesAvailable; }
            set { copiesAvailable = value >= 0 ? value : 0; }
        }


        public void DisplayInfo()
        {
            Console.WriteLine($"ISBN: {ISBN}, Title: {Title}, Author: {Author}, Year: {Year}, Copies Available: {CopiesAvailable}");
        }
        public void PrintDetails()
        {
            DisplayInfo();
        }

    }
}
