using TechnoRishi.LMS.Repository.DataModel;
using TechnoRishi.LMS.ViewModel.BookModel;
using TechnoRishi.LMS.ViewModel.BorrowedBookModel;
using TechnoRishi.LMS.ViewModel.MemberModel;

namespace TechnoRishi.LMS.Serives.Mapper;

public static class BorrowedBookMapper
{
    public static BorrowedBookRequest ToResponse(BorrowedBook entity)
    {
        if (entity == null) return null;

        return new BorrowedBookRequest
        {
            Id = entity.Id,
            BookId = entity.BookId,
            MemberId = entity.MemberId,
            BorrowedDate = entity.BorrowedDate,
            Book = entity.Book,
            Member = entity.Member
        };
    }

    public static BorrowedBook ToEntity(BorrowedBookRequest dto)
    {
        if (dto == null) return null;

        return new BorrowedBook
        {
            Id = dto.Id,
            BookId = dto.BookId,
            MemberId = dto.MemberId,
            BorrowedDate = dto.BorrowedDate,
            Book = dto.Book,
            Member = dto.Member
        };
    }

    public static List<BorrowedBookRequest> ToResponseList(IEnumerable<BorrowedBook> entities)
    {
        if (entities == null) return new List<BorrowedBookRequest>();

        return entities.Select(ToResponse).ToList();
    }
}
