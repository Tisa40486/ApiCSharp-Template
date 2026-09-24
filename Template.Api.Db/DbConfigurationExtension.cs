using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Db.DbContexts;

namespace Template.Db
{
    public static class DbConfigurationExtension
    {
        public static void AppTemplateApiContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DataBase");

            services.AddDbContext<TemplateApiDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                    mysqlOptions =>
                    {
                        mysqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                                    .UseRelationalNulls()
                                    .EnableRetryOnFailure(
                                        maxRetryCount: 5,
                                        maxRetryDelay: TimeSpan.FromSeconds(30),
                                        errorNumbersToAdd: null
                                    )
                                    .MigrationsAssembly("Template.Api.Db");
                        mysqlOptions.CommandTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds);
                    }));
        }
    }
}