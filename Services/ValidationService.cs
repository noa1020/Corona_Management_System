using CoronaManagementSystem.Data;
using CoronaManagementSystem.Interfaces;
using CoronaManagementSystem.Models;
using CoronaManagementSystem.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaManagementSystem.Services;

public class ValidationService
{

    public static bool IsValidMember(Member member)
    {
        if (!ValidationFunctions.IsValidIsraeliId(member.MemberId))
            throw new Exception("Invalid israeli id");
        if (!ValidationFunctions.IsValidString(member.FirstName))
            throw new Exception("Invalid first name");
        if (!ValidationFunctions.IsValidString(member.LastName))
            throw new Exception("Invalid last name");
        if (!ValidationFunctions.IsValidBirthDate(member.DateOfBirth))
            throw new Exception("Invalid date of birth");
        if (!ValidationFunctions.IsValidIsraeliLandlinePhone(member.Landlinephone))
            throw new Exception("Invalid landline phone");
        if (!ValidationFunctions.IsValidIsraeliMobilePhone(member.MobilePhone))
            throw new Exception("Invalid mobile phone");
        if (member.Vaccinations?.Count() > 4)
            throw new Exception("You cannot take more than 4 vaccines");
        if (member.RecoveryDate != null && member.IllnessDate > member.RecoveryDate)
            throw new Exception("Recovery date will be only after illness date");
        if ((member.IllnessDate == null && member.RecoveryDate != null)|| member.RecoveryDate < member.IllnessDate)
            throw new Exception("Recovery date will be only after illness date");
        if (!ValidationFunctions.IsValidString(member.City))
            throw new Exception("Invalid city name");
        if (!ValidationFunctions.IsValidString(member.Street))
            throw new Exception("Invalid Street name");
        if (member.HouseNumber < 0)
            throw new Exception("Invalid House number");
        return true;
    }
    public static bool IsValidVaccination(Vaccination vaccination)
    {
        if (!ValidationFunctions.IsValidString(vaccination.Manufacturer))
            throw new Exception("Invalid manufacturer name");
        if (!ValidationFunctions.IsValidString(vaccination.VaccinationName))
            throw new Exception("Invalid vaccination name");
        return true;
    }
}