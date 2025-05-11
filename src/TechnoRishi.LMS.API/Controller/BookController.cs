using Azure.Core;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using TechnoRishi.LMS.Serives.Interfaces;
using TechnoRishi.LMS.ViewModel.BookModel;

namespace TechnoRishi.LMS.API.Controller;

public class BookController : BaseController
{
    public BookController() : base("book")
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/GetAllBooks", GetBooks);
        app.MapGet("/GetBookById/{id:int}", GetBook).WithName("GetBook");

        app.MapPost("/Add", AddBook).WithName("CreateBook");

        app.MapPut("/Update", UpdateBook).WithName("UpdateBook");

        app.MapDelete("/Delete/{id:int}", DeleteBook).WithName("DeleteBook");
    }

    private async Task<IResult> DeleteBook(int id,IBookService bookService, CancellationToken cancellationToken)
    {
        var result = await bookService.DeleteBook(id, cancellationToken);
        return Results.Ok(result);

    }

    private async Task<IResult> UpdateBook(BookRequest bookRequest, IBookService bookService, IValidator<BookRequest> validator, CancellationToken cancellationToken)
    {
        var validation = await validator.ValidateAsync(bookRequest, cancellationToken);
        if (!validation.IsValid)
        {
            var errors = validation.Errors
                .Select(e => new { e.PropertyName, e.ErrorMessage });

            return Results.BadRequest(errors);
        }

        var result = await bookService.UpdateBook(bookRequest, cancellationToken);
        return Results.Ok(result);

    }

    private async Task<IResult> AddBook(BookRequest request,IBookService bookService,IValidator<BookRequest> validator,CancellationToken cancellationToken)
    {
        var validation = await validator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
        {
            var errors = validation.Errors
                .Select(e => new { e.PropertyName, e.ErrorMessage });

            return Results.BadRequest(errors);
        }

        var createdBook = await bookService.AddBook(request, cancellationToken);
        return Results.Ok(createdBook);
    }

    private async Task<IResult> GetBook(int id,IBookService bookService, CancellationToken cancellationToken)
    {
        var result = await bookService.GetBook(id, cancellationToken);
        return Results.Ok(result);
    }

    private async Task<IResult> GetBooks([AsParameters] BookFilterRequest bookFilterRequest, IBookService bookService,CancellationToken token)
    {
        var result = await bookService.GetBooks(bookFilterRequest, token);
        return Results.Ok(result);
    }
}