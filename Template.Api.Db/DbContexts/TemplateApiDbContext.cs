using Microsoft.EntityFrameworkCore;
using Template.Data.DbContexts;
using Template.Model;

namespace Template.Db.DbContexts
{
    public class TemplateApiDbContext : BaseDbContext<TemplateApiDbContext>, ITemplateApiDbContext
    {
        public TemplateApiDbContext(DbContextOptions<TemplateApiDbContext> options) : base(options)
        {
        }
        public DbSet<TemplateDao> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the entity mappings here if needed
        }
    }
}