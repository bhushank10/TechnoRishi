using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoRishi.LMS.ViewModel.MemberModel;

public class MemberRequest
{
    public int MemberId { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime MembershipStartDate { get; set; }
}
public class MemberRequestValidator : AbstractValidator<MemberRequest>
{
    public MemberRequestValidator()
    {
        RuleFor(m => m.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100);

        RuleFor(m => m.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email is required.")
            .MaximumLength(150);

        RuleFor(m => m.MembershipStartDate)
            .LessThanOrEqualTo(DateTime.Today).WithMessage("Membership start date cannot be in the future.");
    }
}