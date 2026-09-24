using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Template.Data.Model;

namespace Template.Data.DbContexts
{
    public class BaseDbContext<TContext> : DbContext, IBaseDbContext where TContext : DbContext
    {
        public BaseDbContext(DbContextOptions<TContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public new EntityEntry<TModelDao> Entry<TModelDao>(TModelDao entry) where TModelDao : class, IModelDao
        {
            return base.Entry(entry);
        }
    }
}