using System.ComponentModel.DataAnnotations;
using CoronaManagementSystem.Validation;
namespace CoronaManagementSystem.Models;

public class Vaccination
{
    [Key]
    public int VaccinationId { get; set; }
    [MaxLength(50)]
    [Required]
    public string? VaccinationName { get; set; }
    [MaxLength(50)]
    [Required]
    public string? Manufacturer { get; set; }

}
