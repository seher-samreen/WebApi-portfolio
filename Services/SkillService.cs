using PortfolioManagementApi.Models;
using PortfolioManagementApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioManagementApi.Services
{
    public class SkillService : ISkillService
    {
        private readonly IRepository<Skill> _skillRepository;

        public SkillService(IRepository<Skill> skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
        {
            return await _skillRepository.GetAllAsync();
        }

        public async Task<Skill> GetSkillByIdAsync(int id)
        {
            return await _skillRepository.GetByIdAsync(id);
        }

        public async Task<Skill> AddSkillAsync(Skill skill)
        {
            await _skillRepository.AddAsync(skill);
            return skill;
        }

        public async Task<Skill> UpdateSkillAsync(Skill skill)
        {
            await _skillRepository.UpdateAsync(skill);
            return skill;
        }

        public async Task<bool> SoftDeleteSkillAsync(int id)
        {
            await _skillRepository.SoftDeleteAsync(id);
            return true;
        }
    }
}
