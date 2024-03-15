using AspNetCoreRateLimit;
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
           
            var rateLimitRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint = "*",
                    Limit = 3,
                    Period = "5m"
                }
            };
            builder.Services.Configure<IpRateLimitOptions>(opt =>
            {
                opt.GeneralRules = rateLimitRules;
            });
            builder.Services.AddMemoryCache();
            
            builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            builder.Services.AddInMemoryRateLimiting();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddApplicationService();
            builder.Services.AddPersistenceServices();
           
            builder.Services.AddControllers();
            builder.Services.AddCors(
                options=>options.AddPolicy(
                "open", policy =>
               policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                ));
            builder.Services.AddSwaggerGen();
            return builder.Build();
        }
        public static WebApplication ConfigurePipeline(this WebApplication app) { 
          app.UseCors("open");
            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseIpRateLimiting();
            //app.UseAuthorization();
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
