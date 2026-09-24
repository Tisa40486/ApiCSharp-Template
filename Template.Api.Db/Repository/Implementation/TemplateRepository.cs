using Microsoft.EntityFrameworkCore;
using Template.Data.Repository;
using Template.Db.DbContexts;
using Template.Model;


namespace Template.Db.Repository.Implementation
{
    public class TemplateRepository : BaseRepository<ITemplateApiDbContext, TemplateDao>, ITemplateRepository
    {
        private readonly ITemplateApiDbContext _templateApiDbContext;
        public TemplateRepository(ITemplateApiDbContext context) : base(context)
        {
            _templateApiDbContext = context;

        }
    }
}