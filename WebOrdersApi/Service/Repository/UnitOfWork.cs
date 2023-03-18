using WebOrdersApi.Data.DB;
using WebOrdersApi.Data.Entity;
using WebOrdersApi.Service.IRepository;

namespace WebOrdersApi.Service.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGRepository<Order> _orders;
        public IGRepository<Product> _products;
        public IGRepository<OrderProduct> _orderProducts;
        public IGRepository<Client> _client;

        public IGRepository<Order> Orders => _orders ??= new GRepository<Order>(_context);
        public IGRepository<Product> Products => _products ??= new GRepository<Product>(_context);
        public IGRepository<OrderProduct> OrderProducts => _orderProducts ??= new GRepository<OrderProduct>(_context);
        public IGRepository<Client> Clients => _client ??= new GRepository<Client>(_context);

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
