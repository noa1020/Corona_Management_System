using Microsoft.AspNetCore.Mvc;
using CoronaManagementSystem.Interfaces;
using CoronaManagementSystem.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http.Features;

namespace CoronaManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VaccinationController : ControllerBase
    {
        private readonly IVaccinationService vaccinationService;

        public VaccinationController(IVaccinationService vaccinationService)
        {
            this.vaccinationService = vaccinationService;
        }

        //Get all vaccinations.
        [HttpGet]
        public async Task<List<Vaccination>?> GetAll()
        {
            return await vaccinationService.GetAll();
        }

        //Add new vaccination.
        [HttpPost]
        public async Task<IActionResult> Add(Vaccination newvaccination)
        {
            try
            {
                await vaccinationService.Add(newvaccination);
                return CreatedAtAction(nameof(Add), new { id = newvaccination.VaccinationId }, newvaccination);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errorMessage = ex.Message });
            }
        }
        //Update an existing vaccination.
        [HttpPut]
        public async Task<IActionResult> Update(Vaccination vaccinationToUpdate)
        {
            try
            {
                await vaccinationService.Update(vaccinationToUpdate);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Delete vaccination by ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await vaccinationService.Delete(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
