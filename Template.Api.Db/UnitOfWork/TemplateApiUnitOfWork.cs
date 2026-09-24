using Template.Db.DbContexts;
using Template.Db.Repository;
using Template.Db.UnitOfWork;

namespace KairoApi.Db.UnitOfWork
{
    public class TemplateApiUnitOfWork : ITemplateApiUnitOfWork
    {
        public ITemplateApiDbContext Context { get; }
        public ITemplateRepository TemplateRepository { get; }

        public TemplateApiUnitOfWork(
            ITemplateApiDbContext context, 
            ITemplateRepository templateRepository)
        {
            Context = context;
            TemplateRepository = templateRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}