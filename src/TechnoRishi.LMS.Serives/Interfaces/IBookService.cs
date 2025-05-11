using TechnoRishi.LMS.ViewModel.BookModel;

namespace TechnoRishi.LMS.Serives.Interfaces;

public interface IBookService
{
    Task<List<BookRequest>> GetBooks(BookFilterRequest filter, CancellationToken token);
    Task<BookRequest> GetBook(int id, CancellationToken token);
    Task<bool> DeleteBook(int id, CancellationToken token);
    Task<BookRequest> AddBook(BookRequest bookResponce, CancellationToken token);
    Task<BookRequest> UpdateBook(BookRequest bookResponce, CancellationToken token);
}
