using Microsoft.AspNetCore.Mvc;
using PortfolioManagementApi.Models;
using PortfolioManagementApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetAllSkills()
        {
            var skills = await _skillService.GetAllSkillsAsync();
            return Ok(skills);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkillById(int id)
        {
            var skill = await _skillService.GetSkillByIdAsync(id);
            if (skill == null)
                return NotFound();
            return Ok(skill);
        }

        [HttpPost]
        public async Task<ActionResult> AddSkill(Skill skill)
        {
            var createdSkill = await _skillService.AddSkillAsync(skill);
            return CreatedAtAction(nameof(GetSkillById), new { id = createdSkill.Id }, createdSkill);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSkill(int id, Skill skill)
        {
            if (id != skill.Id) return BadRequest("Skill ID mismatch");
            await _skillService.UpdateSkillAsync(skill);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> SoftDeleteSkill(int id)
        {
            await _skillService.SoftDeleteSkillAsync(id);
            return NoContent();
        }
    }
}
