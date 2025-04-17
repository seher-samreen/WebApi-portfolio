using Microsoft.EntityFrameworkCore;
using PortfolioManagementApi.Data;
using PortfolioManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioManagementApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null || !(entity is ISoftDeletable deletable))
                return false;

            deletable.IsDeleted = true;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
