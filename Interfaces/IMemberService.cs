using CoronaManagementSystem.Models;

namespace CoronaManagementSystem.Interfaces
{
    public interface IMemberService
    {
        Task<List<Member>?> GetAll();
        Task<bool> Delete(string id);
        Task<bool> Update(Member newMember);
        Task<Member?> GetById(string id);
        Task<bool> Add(Member newMember);
        void UpdateMemberProperties(Member existingMember, Member newMember);
    }
}