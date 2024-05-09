using CoronaManagementSystem.Models;
using System.Collections.Generic;

namespace CoronaManagementSystem.Interfaces
{
    public interface IVaccinationService
    {
        Task<List<Vaccination>?> GetAll();
        Task<bool> Delete(int id);
        Task<Vaccination?> GetById(int id);
        Task<bool> Update(Vaccination newVaccination);
        Task<bool> Add(Vaccination newVaccination);

    }
}