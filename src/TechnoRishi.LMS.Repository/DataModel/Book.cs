using System.ComponentModel.DataAnnotations;

namespace TechnoRishi.LMS.Repository.DataModel;

public class Book
{
    public int BookId { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string Genre { get; set; }

    public int? PublishedYear { get; set; } 
    public string AvailabilityStatus { get; set; }
    public int? BorrowedBy { get; set; }
    public DateTime? BorrowedDate { get; set; }
}
