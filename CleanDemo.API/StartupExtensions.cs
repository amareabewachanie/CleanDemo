using CleanDemo.Application;
using CleanDemo.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

namespace CleanDemo.API

{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationService();
            builder.Services.AddPersistenceServices();
            builder.Services.AddControllers();
            builder.Services.AddCors(
                options=>options.AddPolicy(
                "open", policy =>
               policy.WithOrigins("http://localhost:4200", "http://localhost:5013")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .SetIsOriginAllowed(pol=>true)
                  .AllowCredentials()
                ));
            builder.Services.AddSwaggerGen();
            return builder.Build();
        }
        public static WebApplication ConfgiurePipeline(this WebApplication app) { 
          app.UseCors("open");
            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapControllers();
            return app;
        }
        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scop = app.Services.CreateScope();
            try
            {
                var context = scop.ServiceProvider.GetServices<OcraDbContext>();
                if (context != null)
                {
                    await context.FirstOrDefault().Database.EnsureDeletedAsync();
                    await context.FirstOrDefault().Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                // Add logging here later on
            }
            }
        }
}
