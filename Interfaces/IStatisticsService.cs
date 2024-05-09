using CoronaManagementSystem.Models;

namespace CoronaManagementSystem.Interfaces
{
    public interface IStatisticsService
    {
        Task<int> GetAllNotVaccinated();
        Task<List<DateTime>?> GetDatesOfIllness();
    }
}