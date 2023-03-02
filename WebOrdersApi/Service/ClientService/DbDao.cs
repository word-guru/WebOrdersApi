using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WebOrdersApi.Model;
using WebOrdersApi.Model.Entity;

namespace WebOrdersApi.Service.ClientService
{
    public class DbDao<TEntity> : IDao<TEntity> where TEntity : class,IEntity
    {
        private readonly AppDbContext _context;
        private DbSet<TEntity> Entities => _context.Set<TEntity>();
        string _errorMessage = string.Empty;

        public DbDao(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<TEntity>> GetAll()
            => await Entities.ToListAsync();
        public async Task<TEntity> GetById(int id) 
            => await Entities.SingleOrDefaultAsync(t => t.Id == id);
       

        public async Task<TEntity> Add(TEntity entity)
        {

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var product = await Entities
                .FirstAsync(p => p.Id == id);
            _context.Remove(product);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
