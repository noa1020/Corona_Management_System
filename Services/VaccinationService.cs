using CoronaManagementSystem.Data;
using CoronaManagementSystem.Interfaces;
using CoronaManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaManagementSystem.Services;

public class VaccinationService : IVaccinationService
{
    private readonly IRepository _repository;

    public VaccinationService(IRepository repository)
    {
        _repository = repository;
    }

    //Get all vaccinations
    public async Task<List<Vaccination>?> GetAll()
    {
        return await _repository.GetAllVaccinations();
    }

    //Get vaccination by id
    public async Task<Vaccination?> GetById(int id)
    {
        return await _repository.GetVaccinationById(id);
    }

    //Add a new vaccination to the database
    public async Task<bool> Add(Vaccination? newVaccination)
    {
        if (newVaccination == null)
        {
            throw new ArgumentNullException(nameof(newVaccination), "vaccination object is null");
        }
        Vaccination? existingvaccination = await GetById(newVaccination.VaccinationId!);
        if (existingvaccination != default)
        {
            throw new ArgumentException("vaccination ID already exists");
        }
        try
        {
            ValidationService.IsValidVaccination(newVaccination);
            await _repository.AddVaccination(newVaccination);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred: {ex.Message}");
        }
    }

    // Update an existing vaccination in the database
    public async Task<bool> Update(Vaccination? newVaccination)
    {
        if (newVaccination == null)
        {
            throw new ArgumentNullException(nameof(newVaccination), "vaccination object is null");
        }
        Vaccination? vaccination = await GetById(newVaccination.VaccinationId!);
        if (vaccination == null)
        {
            throw new ArgumentException("vaccination not found");
        }
        try
        {
            Vaccination? existingVaccination = await GetById(newVaccination.VaccinationId);
            if (existingVaccination == null)
            {
                return false;
            }
            ValidationService.IsValidVaccination(newVaccination);
            // Update vaccination properties
            existingVaccination.Manufacturer = newVaccination.Manufacturer ?? existingVaccination.Manufacturer;
            existingVaccination.VaccinationName = newVaccination.VaccinationName ?? existingVaccination.VaccinationName;
            await _repository.UpdateVaccination(existingVaccination);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating vaccination: {ex.Message}");
        }
    }

    // Delete a vaccination from the database
    public async Task<bool> Delete(int id)
    {
        Vaccination? vaccination = await GetById(id);
        if (vaccination == null)
        {
            throw new ArgumentException("vaccination not found");
        }
        try
        {
            await _repository.DeleteVaccination(vaccination);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting vaccination with ID {id}: {ex.Message}");
        }
    }
}

