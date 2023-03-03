using WebOrdersApi.Model.Entity;

namespace WebOrdersApi.Service.ClientService
{
    //DAO
    public interface IDao<TEntity> where TEntity : class,IEntity
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
