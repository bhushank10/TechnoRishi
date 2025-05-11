using Azure.Core;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using TechnoRishi.LMS.Serives.Interfaces;
using TechnoRishi.LMS.ViewModel.MemberModel;

namespace TechnoRishi.LMS.API.Controller;

public class MemberController : BaseController
{
    public MemberController() : base("member")
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/GetAllMembers", GetMembers);
        app.MapGet("/GetMemberById/{id:int}", GetMember).WithName("GetMember");

        app.MapPost("/Add", AddMember).WithName("CreateMember");

        app.MapPut("/Update", UpdateMember).WithName("UpdateMember");

        app.MapDelete("/Delete/{id:int}", DeleteMember).WithName("DeleteMember");
    }

    private async Task<IResult> DeleteMember(int id,IMemberService MemberService, CancellationToken cancellationToken)
    {
        var result = await MemberService.DeleteMember(id, cancellationToken);
        return Results.Ok(result);

    }

    private async Task<IResult> UpdateMember(MemberRequest MemberRequest, IMemberService MemberService, IValidator<MemberRequest> validator, CancellationToken cancellationToken)
    {
        var validation = await validator.ValidateAsync(MemberRequest, cancellationToken);
        if (!validation.IsValid)
        {
            var errors = validation.Errors
                .Select(e => new { e.PropertyName, e.ErrorMessage });

            return Results.BadRequest(errors);
        }

        var result = MemberService.UpdateMember(MemberRequest, cancellationToken);
        return Results.Ok(result);

    }

    private async Task<IResult> AddMember(MemberRequest request,IMemberService MemberService,IValidator<MemberRequest> validator,CancellationToken cancellationToken)
    {
        var validation = await validator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
        {
            var errors = validation.Errors
                .Select(e => new { e.PropertyName, e.ErrorMessage });

            return Results.BadRequest(errors);
        }

        var createdMember = await MemberService.AddMember(request, cancellationToken);
        return Results.Ok(createdMember);
    }

    private async Task<IResult> GetMember(int id,IMemberService MemberService, CancellationToken cancellationToken)
    {
        var result = await MemberService.GetMember(id, cancellationToken);
        return Results.Ok(result);
    }

    private async Task<IResult> GetMembers([AsParameters] MemberFilterRequest MemberFilterRequest, IMemberService MemberService,CancellationToken token)
    {
        var result = await MemberService.GetMembers(MemberFilterRequest, token);
        return Results.Ok(result);
    }
}