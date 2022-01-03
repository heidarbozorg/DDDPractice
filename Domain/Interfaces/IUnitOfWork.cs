namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : Base.BaseEntity;

        /// <summary>
        /// Save changes on the persistence database.
        /// </summary>
        /// <returns></returns>
        Task<int> Complete();
    }
}