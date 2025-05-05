using PortfolioManagementApi.Models;
using PortfolioManagementApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioManagementApi.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IRepository<Experience> _experienceRepository;

        public ExperienceService(IRepository<Experience> experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public async Task<IEnumerable<Experience>> GetAllExperiencesAsync()
        {
            return await _experienceRepository.GetAllAsync();
        }

        public async Task<Experience> GetExperienceByIdAsync(int id)
        {
            return await _experienceRepository.GetByIdAsync(id);
        }

        public async Task<Experience> AddExperienceAsync(Experience experience)
        {
            return await _experienceRepository.AddAsync(experience);
        }

        public async Task<Experience> UpdateExperienceAsync(Experience experience)
        {
            return await _experienceRepository.UpdateAsync(experience);
        }

        public async Task<bool> SoftDeleteExperienceAsync(int id)
        {
            return await _experienceRepository.SoftDeleteAsync(id);
        }
    }
}
