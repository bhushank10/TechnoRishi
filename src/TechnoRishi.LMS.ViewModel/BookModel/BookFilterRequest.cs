namespace TechnoRishi.LMS.ViewModel.BookModel;

public class BookFilterRequest
{
    public string? Title { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}