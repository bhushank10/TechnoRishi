using FluentValidation;

namespace TechnoRishi.LMS.ViewModel.BookModel;

public class BookRequest
{
    public int BookId { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string Genre { get; set; }

    public int? PublishedYear { get; set; }
    public string AvailabilityStatus { get; set; }
    public int? BorrowedBy { get;  set; }
    public DateTime? BorrowedDate { get;  set; }
}

public class BookRequestValidator : AbstractValidator<BookRequest>
{
    public BookRequestValidator()
    {
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200);

        RuleFor(b => b.Author)
            .NotEmpty().WithMessage("Author is required.")
            .MaximumLength(100);

        RuleFor(b => b.Genre)
            .NotEmpty().WithMessage("Genre is required.")
            .MaximumLength(50);

        RuleFor(b => b.PublishedYear)
            .InclusiveBetween(1000, DateTime.Now.Year)
            .When(b => b.PublishedYear.HasValue);

        RuleFor(b => b.AvailabilityStatus)
            .NotEmpty().WithMessage("Availability status is required.")
            .Must(status => status == "Available" || status == "Borrowed")
            .WithMessage("AvailabilityStatus must be either 'Available' or 'Borrowed'.");

        RuleFor(b => b.BorrowedBy)
            .NotNull().When(b => b.AvailabilityStatus == "Borrowed")
            .WithMessage("BorrowedBy is required if the book is borrowed.");

        RuleFor(b => b.BorrowedDate)
            .NotNull().When(b => b.AvailabilityStatus == "Borrowed")
            .WithMessage("BorrowedDate is required if the book is borrowed.");
    }
}