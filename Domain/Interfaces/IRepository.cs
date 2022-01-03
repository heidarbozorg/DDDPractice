using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : Base.BaseEntity
    {
        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(object key);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteRangeAsync(IEnumerable<T> entities);

        Task<T> GetByIdAsync(object key);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAllAsync();
    }
}