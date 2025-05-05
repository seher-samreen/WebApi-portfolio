using Microsoft.EntityFrameworkCore;
using PortfolioManagementApi.Data;
using PortfolioManagementApi.Models;

namespace PortfolioManagementApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _context.Users.Where(u => !u.IsDeleted).ToListAsync();

        public async Task<User?> GetByIdAsync(int id) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);

        public async Task<User?> GetByUsernameAsync(string username) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Username == username && !u.IsDeleted);

        public async Task<User> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user == null) return false;
            user.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null || user.IsDeleted) return false;
            user.IsDeleted = true;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
