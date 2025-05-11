using TechnoRishi.LMS.Repository.DataModel;
using TechnoRishi.LMS.ViewModel.MemberModel;

namespace TechnoRishi.LMS.Serives.Mapper;

public static class MemberMapper
{
    public static MemberRequest ToResponse(Member Member)
    {
        if (Member == null) return null;

        return new MemberRequest
        {
            MemberId = Member.MemberId,
            Name = Member.Name,
            Email = Member.Email,
            MembershipStartDate = Member.MembershipStartDate
        };
    }

    public static Member ToEntity(MemberRequest response)
    {
        if (response == null) return null;

        return new Member
        {
            MemberId = response.MemberId,
            Name = response.Name,
            Email = response.Email,
            MembershipStartDate = response.MembershipStartDate
        };
    }

    public static List<MemberRequest> ToResponseList(IEnumerable<Member> Members)
    {
        if (Members == null) return new List<MemberRequest>();

        return Members.Select(ToResponse).ToList();
    }

}
