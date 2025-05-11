using TechnoRishi.LMS.Repository.DataModel;
using TechnoRishi.LMS.Repository.Interfaces;
using TechnoRishi.LMS.Serives.Interfaces;
using TechnoRishi.LMS.Serives.Mapper;
using TechnoRishi.LMS.ViewModel.BookModel;

namespace TechnoRishi.LMS.Serives;

public class BookService : IBookService
{
    private readonly IRepository<Book> bookRepository;

    public BookService(IRepository<Book> bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    public async Task<BookRequest> AddBook(BookRequest bookResponce, CancellationToken token)
    {
        var bookEntity = BookMapper.ToEntity(bookResponce);
        var data =await bookRepository.Add(bookEntity, token);
        return BookMapper.ToResponse(data);
    }

    public async Task<bool> DeleteBook(int id, CancellationToken token)
    {
        return await bookRepository.Delete(id, token); 
    }

    public async Task<BookRequest> GetBook(int id, CancellationToken token)
    {
        var data = await bookRepository.Get(id, token);
        return BookMapper.ToResponse(data);
    }

    public async Task<List<ViewModel.BookModel.BookRequest>> GetBooks(BookFilterRequest filter, CancellationToken token)
    {
      
        var data = await bookRepository.GetAll<BookFilterRequest>(filter, token);
        return BookMapper.ToResponseList(data);
    }

    public async Task<BookRequest> UpdateBook(BookRequest bookResponce, CancellationToken token)
    {
        var bookEntity = BookMapper.ToEntity(bookResponce);
        var updated = await bookRepository.Update(bookEntity.BookId, bookEntity, token);
        //return BookMapper.ToResponse(data);
        if (!updated)
            return default;

        // Return the updated DTO explicitly
        var book = await bookRepository.Get(bookResponce.BookId,token);
        return BookMapper.ToResponse(book);
    }
}
