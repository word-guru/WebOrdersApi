using System.Linq.Expressions;

namespace WebOrdersApi.Service.IRepository
{
    public interface IGRepository<TEntity> where TEntity : class
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> expression, List<string> includes = null);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}
