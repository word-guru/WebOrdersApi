using WebOrdersApi.Data.Entity;

namespace WebOrdersApi.Service.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGRepository<Order> Orders { get; }
        IGRepository<Product> Products { get; }
        IGRepository<OrderProduct> OrderProducts { get; }
        IGRepository<Client> Clients { get; }

        Task Save();
    }
}
