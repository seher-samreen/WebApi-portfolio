using PortfolioManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioManagementApi.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task<Project> AddProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(Project project);
        Task<bool> SoftDeleteProjectAsync(int id);
    }
}
