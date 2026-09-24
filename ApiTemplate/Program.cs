using Inoks.Api.Hardware.Business;
using Template.Db;
using Microsoft.OpenApi;
using Template.Api.Business.template.Query;

namespace Template.Api.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSwagger", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            builder.Services.RegisterTemplateApiDbContainer();
            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(TemplateGetQuery).Assembly));
            builder.Services.AddAutoMapper(cfg => { }, typeof(ApiProfile).Assembly);
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AppTemplateApiContext(builder.Configuration);

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Api Test",
                    Version = "v1"
                });

                c.AddServer(new OpenApiServer
                {
                    Url = "http://localhost:3000",
                    Description = "Docker"
                });
            });

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Kairo v1");
                c.RoutePrefix = "swagger";
            });
            app.UseCors("AllowSwagger");

            app.UseAuthorization();
            app.MapControllers();
            app.MapGet("/health", () => Results.Ok(new { ok = true, dotnet = Environment.Version.ToString() }));
            app.Run();
        }
    }
}