using WebOrdersApi.Data.Entity;
using WebOrdersApi.Model;

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
