using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebOrdersApi.Model;
using WebOrdersApi.Model.Entity;

namespace WebOrdersApi.Service.ClientService
{
    public class DbDao<TEntity> : IDao<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        private DbSet<TEntity> Entities;
        string _errorMessage = string.Empty;

        public DbDao(AppDbContext context)
        {
            _context = context;
            Entities = context.Set<TEntity>();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
            => await Entities.ToListAsync();
        public async Task<TEntity> GetByIdAsync(int id)
            => await FindByIdAsync(id);
        public async Task<IEnumerable<TEntity>> GetWithIncludeAsync(Expression<Func<TEntity, object>> include)
           => await Entities.Include(include).ToListAsync();


        private async Task<TEntity> FindByIdAsync(int id)
            => await Entities.FindAsync(id);
       

        public async Task<TEntity> AddAsync(TEntity entity)
        {

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _context.Remove(FindByIdAsync(id));

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
