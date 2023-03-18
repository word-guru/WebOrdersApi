using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebOrdersApi.Data.DB;
using WebOrdersApi.Service.IRepository;

namespace WebOrdersApi.Service.Repository
{
    public class GRepository<TEntity> : IGRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        private DbSet<TEntity> Entities;

        public GRepository(AppDbContext context)
        {
            _context = context;
            Entities = context.Set<TEntity>();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            IQueryable<TEntity> query = Entities;
            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> expression, List<string> includes = null)
        {
            IQueryable<TEntity> query = Entities;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

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

        public async Task DeleteAsync(int id)
        {
            var entity = await Entities.FindAsync(id);
            Entities.Remove(entity);
        }
    }
}
