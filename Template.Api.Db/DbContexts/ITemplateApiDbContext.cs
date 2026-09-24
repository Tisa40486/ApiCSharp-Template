using Microsoft.EntityFrameworkCore;
using Template.Data.DbContexts;
using Template.Model;

namespace Template.Db.DbContexts
{
    public interface ITemplateApiDbContext : IBaseDbContext
    {
        public DbSet<TemplateDao> Users { get; set; }
    }
}   