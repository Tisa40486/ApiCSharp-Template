using Template.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Template.Data.DbContexts
{
    public interface IBaseDbContext
    {
        EntityEntry<TModelDao> Entry<TModelDao>(TModelDao entry) where TModelDao : class, IModelDao;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess = true, CancellationToken cancellationToken = new CancellationToken());
    }
}
