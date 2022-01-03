using Domain.Base;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> Complete()
        {
            return _dbContext.SaveChangesAsync();
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repositories.BaseRepository<T>(_dbContext);
        }
    }
}
