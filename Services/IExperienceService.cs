using PortfolioManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioManagementApi.Services
{
    public interface IExperienceService
    {
        Task<IEnumerable<Experience>> GetAllExperiencesAsync();
        Task<Experience> GetExperienceByIdAsync(int id);
        Task<Experience> AddExperienceAsync(Experience experience);
        Task<Experience> UpdateExperienceAsync(Experience experience);
        Task<bool> SoftDeleteExperienceAsync(int id);
    }
}
