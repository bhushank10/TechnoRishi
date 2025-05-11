using FluentValidation;
using System.ComponentModel.DataAnnotations;
using TechnoRishi.LMS.Repository.DataModel;

namespace TechnoRishi.LMS.ViewModel.BorrowedBookModel;

public class BorrowedBookRequest
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int MemberId { get; set; }

    public DateTime BorrowedDate { get; set; } = DateTime.Now;

    public Book Book { get; set; }
    public Member Member { get; set; }
}

public class BorrowedBookRequestValidator : AbstractValidator<BorrowedBookRequest>
{
    public BorrowedBookRequestValidator()
    {
        RuleFor(b => b.BookId)
            .GreaterThan(0).WithMessage("BookId must be a valid positive number.");

        RuleFor(b => b.MemberId)
            .GreaterThan(0).WithMessage("MemberId must be a valid positive number.");

        RuleFor(b => b.BorrowedDate)
            .NotEmpty().WithMessage("BorrowedDate is required.")
            .LessThanOrEqualTo(DateTime.Today).WithMessage("BorrowedDate cannot be in the future.");

        RuleFor(b => b.Book)
            .NotNull().WithMessage("Book details are required.");

        RuleFor(b => b.Member)
            .NotNull().WithMessage("Member details are required.");
    }
}