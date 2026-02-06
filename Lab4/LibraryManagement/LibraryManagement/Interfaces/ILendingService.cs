namespace LibraryManagement.Interfaces
{
    public interface ILendingService
    {
        bool BorrowBook(string memberId, string bookId);
        void ReturnBook(string memberId, string bookId);
    }
}