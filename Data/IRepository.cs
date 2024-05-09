using CoronaManagementSystem.Models;

namespace CoronaManagementSystem.Data
{
    public interface IRepository
    {
        Task<List<Member>?> GetAllMembers();
        Task<bool> DeleteMember(Member member);
        Task<Member?> GetMemberById(string id);
        Task<bool> AddMember(Member newMember);
        Task<bool> UpdateMember(Member member);
        Task<List<Vaccination>?> GetAllVaccinations();
        Task<bool> DeleteVaccination(Vaccination vaccination);
        Task<bool> UpdateVaccination(Vaccination vaccination);
        Task<Vaccination?> GetVaccinationById(int id);
        Task<bool> AddVaccination(Vaccination newVaccination);
        Task SaveChanges();
    }
}