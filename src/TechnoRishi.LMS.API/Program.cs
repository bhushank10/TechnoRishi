using Carter;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechnoRishi.LMS.API.Controller;
using TechnoRishi.LMS.Framework;
using TechnoRishi.LMS.Repository;
using TechnoRishi.LMS.Repository.DataModel;
using TechnoRishi.LMS.Repository.Interfaces;
using TechnoRishi.LMS.Serives;
using TechnoRishi.LMS.Serives.Interfaces;
using TechnoRishi.LMS.ViewModel.BookModel;
using TechnoRishi.LMS.ViewModel.BorrowedBookModel;
using TechnoRishi.LMS.ViewModel.MemberModel;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext (LibraryContext) as Scoped
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDB")));

// Register Repository and BookService as Scoped
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));  // Generic Repository
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IBorrowedBookService, BorrowedBookService>();
builder.Services.AddValidatorsFromAssemblyContaining<BookRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<MemberRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<BorrowedBookRequestValidator>();


builder.Services.AddCarter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddLogging();
var app = builder.Build();

app.MapCarter();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
