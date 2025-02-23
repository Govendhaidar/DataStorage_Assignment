using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<bool> AlreadyExistsAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> UpdateAsync(TEntity updatedEntity);
        Task<bool> DeleteAsync(TEntity entity);

    }
}