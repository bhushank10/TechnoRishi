using TechnoRishi.LMS.ViewModel.BorrowedBookModel;

namespace TechnoRishi.LMS.Serives.Interfaces;

public interface IBorrowedBookService
{
    Task<List<BorrowedBookRequest>> GetBorrowedBooks(BorrowedBookFilterRequest filter, CancellationToken token);
    Task<BorrowedBookRequest> GetBorrowedBook(int id, CancellationToken token);
    Task<bool> DeleteBorrowedBook(int id, CancellationToken token);
    Task<BorrowedBookRequest> AddBorrowedBook(BorrowedBookRequest BorrowedBookResponce, CancellationToken token);
    Task<bool> UpdateBorrowedBook(BorrowedBookRequest BorrowedBookResponce, CancellationToken token);
    Task<bool> ReturnBookAsync(int borrowedBookId,CancellationToken token);
    Task<bool> BorrowBookAsync(BorrowedBookRequest BorrowedBookResponce, CancellationToken token);

}
