using Template.Data.Repository;
using Template.Db.DbContexts;
using Template.Model;

namespace Template.Db.Repository
{
    public interface ITemplateRepository : IBaseRepository<ITemplateApiDbContext, TemplateDao>    
    {
    }
}
