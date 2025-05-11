using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoRishi.LMS.Repository.DataModel;
using TechnoRishi.LMS.ViewModel.BookModel;

namespace TechnoRishi.LMS.Serives.Mapper;

public static class BookMapper
{
    public static BookRequest ToResponse(Book book)
    {
        if (book == null) return null;

        return new BookRequest
        {
            BookId = book.BookId,
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            PublishedYear = book.PublishedYear,
            AvailabilityStatus = book.AvailabilityStatus,
            BorrowedBy = book.BorrowedBy,
            BorrowedDate = book.BorrowedDate
        };
    }

    public static Book ToEntity(BookRequest response)
    {
        if (response == null) return null;

        return new Book
        {
            BookId = response.BookId,
            Title = response.Title,
            Author = response.Author,
            Genre = response.Genre,
            PublishedYear = response.PublishedYear,
            AvailabilityStatus = response.AvailabilityStatus,
            BorrowedBy = response.BorrowedBy,
            BorrowedDate = response.BorrowedDate
        };
    }

    public static List<BookRequest> ToResponseList(IEnumerable<Book> books)
    {
        if (books == null) return new List<BookRequest>();

        return books.Select(ToResponse).ToList();
    }

}
