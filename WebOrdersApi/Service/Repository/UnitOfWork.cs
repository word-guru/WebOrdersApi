using WebOrdersApi.Model;
using WebOrdersApi.Model.Entity;
using WebOrdersApi.Service.IRepository;

namespace WebOrdersApi.Service.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGRepository<Order> Orders => throw new NotImplementedException();

        public IGRepository<Product> Products => throw new NotImplementedException();

        public IGRepository<OrderProduct> OrderProducts => throw new NotImplementedException();

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
