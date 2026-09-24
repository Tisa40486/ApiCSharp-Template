using KairoApi.Db.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Template.Db.DbContexts;
using Template.Db.Repository;
using Template.Db.Repository.Implementation;
using Template.Db.UnitOfWork;

namespace Template.Db
{
    public static class DbRegisterExtension
    {
        public static void RegisterTemplateApiDbContainer(this IServiceCollection services)
        {
            services.AddScoped<ITemplateApiDbContext, TemplateApiDbContext>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();


            services.AddScoped<ITemplateApiUnitOfWork, TemplateApiUnitOfWork>();
        }
    }
}