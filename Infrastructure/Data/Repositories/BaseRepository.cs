using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Base;


namespace Infrastructure.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.FromResult(entity);
        }

        public Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(object key)
        {
            var entity = await GetByIdAsync(key);
            if (entity == null)
                return false;

            return await DeleteAsync(entity);
        }

        public Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return Task.FromResult(true);
        }

        public async Task<T> GetByIdAsync(object key)
        {
            var rst = await _dbSet.FindAsync(key);
            return rst;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            var rst = await _dbSet.FirstOrDefaultAsync(expression);
            return rst;
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> expression)
        {
            var rst = await _dbSet.Where(expression).ToListAsync();
            return rst;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
