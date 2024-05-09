using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace CoronaManagementSystem.Models;

public class MemberVaccination
{
    [Key]
    public required int MemberVaccinationId { get; set; }
    [ForeignKey("Members")]
    public required string MemberId { get; set; }
    [ForeignKey("Vaccinations")]
    public required int VaccinationId { get; set; }
    public required DateTime VaccinationDate { get; set; }
}

