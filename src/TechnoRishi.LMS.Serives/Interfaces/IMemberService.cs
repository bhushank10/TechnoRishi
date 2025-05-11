using TechnoRishi.LMS.ViewModel.MemberModel;

namespace TechnoRishi.LMS.Serives.Interfaces;

public interface IMemberService
{
    Task<List<MemberRequest>> GetMembers(MemberFilterRequest filter, CancellationToken token);
    Task<MemberRequest> GetMember(int id, CancellationToken token);
    Task<bool> DeleteMember(int id, CancellationToken token);
    Task<MemberRequest> AddMember(MemberRequest MemberResponce, CancellationToken token);
    Task<bool> UpdateMember(MemberRequest MemberResponce, CancellationToken token);
}
