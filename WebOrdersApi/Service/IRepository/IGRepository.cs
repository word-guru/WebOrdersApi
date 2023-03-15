using System.Linq.Expressions;

namespace WebOrdersApi.Service.IRepository
{
    public interface IGRepository<TEntity> where TEntity : class
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetWithIncludeAsync(Expression<Func<TEntity, object>> include);
    }
}
