using PortfolioManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioManagementApi.Services
{
    public interface ISkillService
    {
        Task<IEnumerable<Skill>> GetAllSkillsAsync();
        Task<Skill> GetSkillByIdAsync(int id);
        Task<Skill> AddSkillAsync(Skill skill);
        Task<Skill> UpdateSkillAsync(Skill skill);
        Task<bool> SoftDeleteSkillAsync(int id);
    }
}
