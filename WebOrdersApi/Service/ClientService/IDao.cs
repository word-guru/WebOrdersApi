using WebOrdersApi.Model.Entity;

namespace WebOrdersApi.Service.ClientService
{
    //DAO
    public interface IDao<TEntity> where TEntity : class,IEntity
    {
        Task<IReadOnlyList<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Add(TEntity entity);
        Task Update(TEntity entity);
        Task<bool> Delete(int id);
    }
}
