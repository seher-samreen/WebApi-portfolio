using PortfolioManagementApi.Models;
using PortfolioManagementApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioManagementApi.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _projectRepository;

        public ProjectService(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _projectRepository.GetByIdAsync(id);
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            await _projectRepository.AddAsync(project);
            return project;
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            await _projectRepository.UpdateAsync(project);
            return project;
        }

        public async Task<bool> SoftDeleteProjectAsync(int id)
        {
            return await _projectRepository.SoftDeleteAsync(id);
        }
    }
}
