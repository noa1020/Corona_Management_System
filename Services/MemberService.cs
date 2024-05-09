using CoronaManagementSystem.Data;
using CoronaManagementSystem.Interfaces;
using CoronaManagementSystem.Models;
using CoronaManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaManagementSystem.Services
{
    public class MemberService : IMemberService
    {
        private readonly IRepository _repository;
        public MemberService(IRepository repository)
        {
            _repository = repository;
        }

        //Get all members
        public async Task<List<Member>?> GetAll()
        {
            return await _repository.GetAllMembers();
        }

        //Get member by id
        public async Task<Member?> GetById(string id)
        {
            return await _repository.GetMemberById(id);
        }

        // Add a new member to the database
        public async Task<bool> Add(Member? newMember)
        {
            if (newMember == null)
            {
                throw new ArgumentNullException(nameof(newMember), "Member object is null");
            }
            Member? existingMember = await GetById(newMember.MemberId!);
            if (existingMember != null)
            {
                throw new ArgumentException("Member ID already exists");
            }
            try
            {
                ValidationService.IsValidMember(newMember);
                await _repository.AddMember(newMember);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding member: {ex.Message}");
            }
        }

        // Update an existing member in the database
        public async Task<bool> Update(Member? newMember)
        {
            if (newMember == null)
            {
                throw new ArgumentNullException(nameof(newMember), "Member object is null");
            }
            Member? existingMember = await GetById(newMember.MemberId!);
            if (existingMember == null)
            {
                throw new ArgumentException("Member not found");
            }
            try
            {
                UpdateMemberProperties(existingMember, newMember);
                ValidationService.IsValidMember(existingMember);
                await _repository.UpdateMember(existingMember);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating member: {ex.Message}");
            }

        }

        // Delete a member from the database
        public async Task<bool> Delete(string id)
        {
            Member? member = await GetById(id);
            if (member == null)
            {
                throw new ArgumentException("Member not found");
            }
            try
            {
                await _repository.DeleteMember(member);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting member with ID {id}: {ex.Message}");
            }
        }

        // Update member properties
        public void UpdateMemberProperties(Member existingMember, Member newMember)
        {
            existingMember.FirstName = newMember.FirstName ?? existingMember.FirstName;
            existingMember.LastName = newMember.LastName ?? existingMember.LastName;
            existingMember.DateOfBirth = newMember.DateOfBirth != default ? newMember.DateOfBirth : existingMember.DateOfBirth;
            existingMember.Landlinephone = newMember.Landlinephone ?? existingMember.Landlinephone;
            existingMember.MobilePhone = newMember.MobilePhone ?? existingMember.MobilePhone;
            existingMember.IllnessDate = newMember.IllnessDate ?? existingMember.IllnessDate;
            existingMember.RecoveryDate = newMember.RecoveryDate ?? existingMember.RecoveryDate;
            existingMember.Image = newMember.Image ?? existingMember.Image;
            existingMember.City = newMember.City ?? existingMember.City;
            existingMember.Street = newMember.Street ?? existingMember.Street;
            existingMember.HouseNumber = newMember.HouseNumber ?? existingMember.HouseNumber;
            existingMember.Vaccinations = newMember.Vaccinations ?? existingMember.Vaccinations;
        }
    }
}
