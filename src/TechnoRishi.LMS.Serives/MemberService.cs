using TechnoRishi.LMS.Repository.DataModel;
using TechnoRishi.LMS.Repository.Interfaces;
using TechnoRishi.LMS.Serives.Interfaces;
using TechnoRishi.LMS.Serives.Mapper;
using TechnoRishi.LMS.ViewModel.BookModel;
using TechnoRishi.LMS.ViewModel.MemberModel;

namespace TechnoRishi.LMS.Serives;

public class MemberService : IMemberService
{
    private readonly IRepository<Member> memberRepository;

    public MemberService(IRepository<Member> memberRepository)
    {
        this.memberRepository = memberRepository;
    }

    public async Task<MemberRequest> AddMember(MemberRequest memberRequest, CancellationToken token)
    {
        var memberEntity = MemberMapper.ToEntity(memberRequest);
        var data =await memberRepository.Add(memberEntity, token);
        return MemberMapper.ToResponse(data);
    }

    public async Task<bool> DeleteMember(int id, CancellationToken token)
    {
        return await memberRepository.Delete(id, token); 
    }

    public async Task<MemberRequest> GetMember(int id, CancellationToken token)
    {
        var data = await memberRepository.Get(id, token);
        return MemberMapper.ToResponse(data);
    }

    public async Task<List<MemberRequest>> GetMembers(MemberFilterRequest filter, CancellationToken token)
    {
      
        var data = await memberRepository.GetAll<MemberFilterRequest>(filter, token);
        return MemberMapper.ToResponseList(data);
    }

    public async Task<bool> UpdateMember(MemberRequest memberRequest, CancellationToken token)
    {
        var memberEntity = MemberMapper.ToEntity(memberRequest);
        var data = await memberRepository.Update(memberEntity.MemberId, memberEntity, token);
        return data;
    }
}
