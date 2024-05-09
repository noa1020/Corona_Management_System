using CoronaManagementSystem.Data;
using CoronaManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaManagementSystem.Data;
public class Repository : IRepository
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }
    //Get all members from the datbase
    public async Task<List<Member>?> GetAllMembers()
    {
        try
        {
            List<Member>? members = await _context.Members.ToListAsync();
            List<MemberVaccination>? mVaccinations = await _context.MemberVaccinations.ToListAsync();
            members.ForEach(member =>
            {
                member.Vaccinations = mVaccinations?.FindAll(mVaccination => mVaccination?.MemberId == member.MemberId);
            });
            return members;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
            return null;
        }
    }

    //Delete member from the datbase
    public async Task<bool> DeleteMember(Member member)
    {
        try
        {
            List<MemberVaccination>? mVaccinations = await _context.MemberVaccinations.ToListAsync();
            mVaccinations = mVaccinations?.FindAll(mVaccination => mVaccination?.MemberId == member.MemberId);
            foreach (var vaccination in mVaccinations)
            {
                if (!member.Vaccinations.Contains(vaccination))
                    _context.MemberVaccinations.Remove(vaccination);
            }
            _context.Members.Remove(member);
            await SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
            return false;
        }

    }

    //Get member by Id from the datbase
    public async Task<Member?> GetMemberById(string id)
    {
        try
        {
            Member? member = await _context.Members.FirstOrDefaultAsync(u => u.MemberId == id);
            if (member == null) return null;
            List<MemberVaccination>? mVaccinations = await _context.MemberVaccinations.ToListAsync();
            member.Vaccinations = mVaccinations?.FindAll(mVaccination => mVaccination.MemberId == member.MemberId);
            return member;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
            return null;
        }

    }

    //Add new member to the datbase
    public async Task<bool> AddMember(Member newMember)
    {
        try
        {
            _context.Members.Add(newMember);
            await SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
            return false;
        }
    }

    //Update member in the datbase
    public async Task<bool> UpdateMember(Member member)
    {
        try
        {
            if (member.Vaccinations != null)
            {
                List<MemberVaccination>? vaccinations = await _context.MemberVaccinations.ToListAsync();
                vaccinations = vaccinations.FindAll(Vaccination => Vaccination?.MemberId == member.MemberId);
                foreach (var vaccination in vaccinations)
                {
                    if (!member.Vaccinations.Contains(vaccination))
                        _context.MemberVaccinations.Remove(vaccination);
                }
            }
            _context.Members.Update(member);
            await SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
            return false;
        }
    }

    //Get all vaccination from the datbase
    public async Task<List<Vaccination>?> GetAllVaccinations()
    {
        try
        {
            return await _context.Vaccinations.ToListAsync();
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
            return null;
        }
    }

    //Delete vaccination to the datbase
    public async Task<bool> DeleteVaccination(Vaccination vaccination)
    {
        try
        {
            _context.Vaccinations.Remove(vaccination);
            await SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
            return false;
        }
    }

    //Get vaccination by Id from the datbase
    public async Task<Vaccination?> GetVaccinationById(int id)
    {
        try
        {
            return await _context.Vaccinations.FirstOrDefaultAsync(a => a.VaccinationId == id);
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
            return null;
        }
    }

    //Add new vaccination to the datbase
    public async Task<bool> AddVaccination(Vaccination newVaccination)
    {
        try
        {
            _context.Vaccinations.Add(newVaccination);
            await SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
            return false;
        }
    }

    //Update vaccination in the datbase
    public async Task<bool> UpdateVaccination(Vaccination vaccination)
    {
        try
        {
            _context.Vaccinations.Update(vaccination);
            await SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
            return false;
        }
    }

    //Update datbase
    public async Task SaveChanges()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
        }
    }
}
