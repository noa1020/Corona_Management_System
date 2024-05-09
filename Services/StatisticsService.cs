using CoronaManagementSystem.Data;
using CoronaManagementSystem.Interfaces;
using CoronaManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaManagementSystem.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IRepository _repository;

        public StatisticsService(IRepository repository)
        {
            _repository = repository;
        }

        //Get count of all not vaccinated members 
        public async Task<int> GetAllNotVaccinated()
        {
            List<Member>? members = await _repository.GetAllMembers();
            int count = 0;
            members.ForEach(member =>
            {
                if (member?.Vaccinations?.Count == 0)
                    count++;
            });
            return count;
        }

        //Get all the dates someone was sick
        public async Task<List<DateTime>?> GetDatesOfIllness()
        {
            List<DateTime>? datesOfIllness = new List<DateTime>();
            List<Member>? members = await _repository.GetAllMembers();
            members.ForEach(member =>
            {
                if (member.IllnessDate != null)
                {
                    DateTime recoveryDate = member.RecoveryDate != null ? (DateTime)member.RecoveryDate : DateTime.Today;
                    DateTime date = (DateTime)member.IllnessDate;
                    datesOfIllness.Add(date);
                    while (date.Date != recoveryDate.Date)
                    {
                        date = date.AddDays(1);
                        datesOfIllness.Add(date);
                    }
                }
            });
            return datesOfIllness;
        }
    }
}
