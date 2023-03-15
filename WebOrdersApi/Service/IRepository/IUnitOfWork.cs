using WebOrdersApi.Model;
using WebOrdersApi.Model.Entity;

namespace WebOrdersApi.Service.IRepository
{
    public interface IUnitOfWork
    {
        IGRepository<Order> Orders { get; }
        IGRepository<Product> Products { get; }
        IGRepository<OrderProduct> OrderProducts { get; }

        Task Save();
    }
}
