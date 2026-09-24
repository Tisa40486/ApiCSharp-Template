using Template.Db.DbContexts;
using Template.Db.Repository;

namespace Template.Db.UnitOfWork
{
    public interface ITemplateApiUnitOfWork
    {
        ITemplateApiDbContext Context { get; }
        ITemplateRepository TemplateRepository { get; }
        Task<int> SaveChangesAsync();
    }
}