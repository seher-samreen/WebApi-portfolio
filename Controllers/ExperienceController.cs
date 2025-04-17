using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioManagementApi.Models;
using PortfolioManagementApi.Repositories;
using PortfolioManagementApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IRepository<Experience> _experienceRepository;

        public ExperienceController(IRepository<Experience> experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experience>>> GetAllExperiences()
        {
            var experiences = await _experienceRepository.GetAllAsync();
            return Ok(experiences);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Experience>> GetExperienceById(int id)
        {
            var experience = await _experienceRepository.GetByIdAsync(id);
            if (experience == null) return NotFound();
            return Ok(experience);
        }

        [HttpPost]
        public async Task<ActionResult> AddExperience(Experience experience)
        {
            await _experienceRepository.AddAsync(experience);
            return CreatedAtAction(nameof(GetExperienceById), new { id = experience.Id }, experience);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExperience(int id, Experience experience)
        {
            if (id != experience.Id) return BadRequest("Experience ID mismatch");
            await _experienceRepository.UpdateAsync(experience);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> SoftDeleteExperience(int id)
        {
            await _experienceRepository.SoftDeleteAsync(id);
            return NoContent();
        }
    }
}
