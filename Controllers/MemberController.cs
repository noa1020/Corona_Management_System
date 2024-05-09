using Microsoft.AspNetCore.Mvc;
using CoronaManagementSystem.Interfaces;
using CoronaManagementSystem.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http.Features;

namespace CoronaManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService memberService;

        public MemberController(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        //Get all members.
        [HttpGet]
        public async Task<List<Member>?> GetAll()
        {
            return await memberService.GetAll();
        }

        //Get member by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<Member?>> GetById(string id)
        {
            Member? myMember = await memberService.GetById(id);
            if (myMember == null)
            {
                return NotFound();
            }
            return myMember;
        }

        //Add new member.
        [HttpPost]
        public async Task<IActionResult> Add(Member newMember)
        {
            try
            {
                await memberService.Add(newMember);
                return CreatedAtAction(nameof(Add), new { id = newMember.MemberId }, newMember);
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
        //Update an existing member.
        [HttpPut]
        public async Task<IActionResult> Update(Member memberToUpdate)
        {
            try
            {
                await memberService.Update(memberToUpdate);
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

        //Delete member by ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await memberService.Delete(id);
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
