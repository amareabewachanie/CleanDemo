using CleanDemo.Application.Contracts.Persistance;
using CleanDemo.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanDemo.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<OcraDbContext>(
                                option =>
                                option
                                    .UseSqlServer("server=./;DataBase=OCRADB;Trusted_Connection=True;")
                ); 
            services.AddScoped(typeof(IAsyncRepository<>),typeof(BaseRepository<>));
            services.AddScoped<IBirthRepository, BirthRepository>();
            services.AddScoped<IDeathRepository,DeathRepository>();
            services.AddScoped<IMarriageRepository,MarriageRepository>();
            return services;
        }
    }
}
