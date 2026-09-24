using Microsoft.EntityFrameworkCore;
using Template.Data.DbContexts;
using Template.Data.Model;

namespace Template.Data.Repository
{
    public class BaseRepository<TContext, TModelDao> : IBaseRepository<TContext, TModelDao>
        where TModelDao : class, IModelDao
        where TContext : IBaseDbContext
    {
        public TContext _context { get; }

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<TModelDao>> GetAllAsync(bool withNoTracking = true)
        {
            IQueryable<TModelDao> query = _context.Set<TModelDao>();

            if (withNoTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public virtual async Task AddAndSaveAsync(TModelDao entity)
        {
            await _context.Set<TModelDao>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<TModelDao?> GetByIdAsync(int id, bool withNoTracking = false)
        {
            IQueryable<TModelDao> query = _context.Set<TModelDao>();

            if (withNoTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveByIdAsync(int id, bool withNoTracking = true)
        {
            var entity = await _context.Set<TModelDao>().FindAsync(id);
            if (entity != null)
                await RemoveAsync(entity);
        }
        public async Task RemoveAsync(TModelDao entity)
        {
            _context.Set<TModelDao>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(TModelDao entity)
        {
            _context.Set<TModelDao>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}