using TechnoRishi.LMS.Repository.DataModel;
using TechnoRishi.LMS.Repository.Interfaces;
using TechnoRishi.LMS.Serives.Interfaces;
using TechnoRishi.LMS.Serives.Mapper;
using TechnoRishi.LMS.ViewModel.BorrowedBookModel;

namespace TechnoRishi.LMS.Serives;

public class BorrowedBookService : IBorrowedBookService
{
    private readonly IRepository<BorrowedBook> borrowedBookRepository;
    private readonly IRepository<Book> bookRepository;

    public BorrowedBookService(IRepository<BorrowedBook> borrowedBookRepository, IRepository<Book> bookRepository)
    {
        this.borrowedBookRepository = borrowedBookRepository;
        this.bookRepository = bookRepository;
    }

    public async Task<BorrowedBookRequest> AddBorrowedBook(BorrowedBookRequest BorrowedBookRequest, CancellationToken token)
    {
        var bookEntity = BorrowedBookMapper.ToEntity(BorrowedBookRequest);
        var data =await borrowedBookRepository.Add(bookEntity, token);
        return BorrowedBookMapper.ToResponse(data);
    }

    public async Task<bool> DeleteBorrowedBook(int id, CancellationToken token)
    {
        return await borrowedBookRepository.Delete(id, token); 
    }

    public async Task<BorrowedBookRequest> GetBorrowedBook(int id, CancellationToken token)
    {
        var data = await borrowedBookRepository.Get(id, token);
        return BorrowedBookMapper.ToResponse(data);
    }

    public async Task<List<BorrowedBookRequest>> GetBorrowedBooks(BorrowedBookFilterRequest filter, CancellationToken token)
    {
      
        var data = await borrowedBookRepository.GetAll<BorrowedBookFilterRequest>(filter, token);
        return BorrowedBookMapper.ToResponseList(data);
    }

    public async Task<bool> UpdateBorrowedBook(BorrowedBookRequest BorrowedBookRequest, CancellationToken token)
    {
        var bookEntity = BorrowedBookMapper.ToEntity(BorrowedBookRequest);
        var data = await borrowedBookRepository.Update(bookEntity.Id, bookEntity, token);
        return data;
    }
    public async Task<bool> ReturnBookAsync(int borrowedBookId, CancellationToken token)
    {
        var borrowedBook = await borrowedBookRepository.Get(borrowedBookId,token);
        if (borrowedBook != null)
        {
            var book = await bookRepository.Get(borrowedBook.BookId,token);
            if (book != null)
            {
                book.AvailabilityStatus = "Available";
                await bookRepository.Update(book.BookId, book, token);
                await borrowedBookRepository.Delete(borrowedBookId, token);
                return true;
            }
        }
        return default;
    }
    public async Task<bool> BorrowBookAsync(BorrowedBookRequest borrowedBookRequest,CancellationToken cancellationToken)
    {
        var book = await bookRepository.Get(borrowedBookRequest.BookId,cancellationToken);
        if (book != null && book.AvailabilityStatus == "Available")
        {
            book.AvailabilityStatus = "Borrowed";
            await bookRepository.Update(book.BookId, book, cancellationToken);
            await borrowedBookRepository.Add(BorrowedBookMapper.ToEntity(borrowedBookRequest), cancellationToken);
            return true;
        }
        return false;
    }
}
