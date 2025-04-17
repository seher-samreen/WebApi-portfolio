using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioManagementApi.Models;
using PortfolioManagementApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null) return NotFound();
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult> AddProject(Project project)
        {
            await _projectService.AddProjectAsync(project);
            return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject(int id, Project project)
        {
            if (id != project.Id) return BadRequest("Project ID mismatch");
            await _projectService.UpdateProjectAsync(project);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> SoftDeleteProject(int id)
        {
            await _projectService.SoftDeleteProjectAsync(id);
            return NoContent();
        }
    }
}
