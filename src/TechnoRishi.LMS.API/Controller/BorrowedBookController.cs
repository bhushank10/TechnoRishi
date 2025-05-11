using Azure.Core;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using TechnoRishi.LMS.Repository.DataModel;
using TechnoRishi.LMS.Serives;
using TechnoRishi.LMS.Serives.Interfaces;
using TechnoRishi.LMS.ViewModel.BorrowedBookModel;
using TechnoRishi.LMS.ViewModel.MemberModel;

namespace TechnoRishi.LMS.API.Controller;

public class BorrowedBookController : BaseController
{
    public BorrowedBookController() : base("BorrowBook")
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
      

        app.MapPost("/borrow", BorrowBook).WithName("BorrowBook");
        app.MapPost("/return/{id}", ReturnBook).WithName("ReturnBook");

        
    }

    private async Task<IResult> BorrowBook(BorrowedBookRequest borrowedBookrequest, IBorrowedBookService borrowedBookService, CancellationToken cancellationToken)
    {
        var result = await borrowedBookService.BorrowBookAsync(borrowedBookrequest,cancellationToken);
        return Results.Ok(result);

    }

    private async Task<IResult> ReturnBook(int id,IBorrowedBookService borrowedBookService, CancellationToken cancellationToken)
    {
        var result = await borrowedBookService.ReturnBookAsync(id, cancellationToken);
        return Results.Ok(result);

    }

    
}