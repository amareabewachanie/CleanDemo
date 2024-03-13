using Microsoft.Extensions.DependencyInjection;

namespace CleanDemo.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(config=>config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            return services;
        }
    }
}
