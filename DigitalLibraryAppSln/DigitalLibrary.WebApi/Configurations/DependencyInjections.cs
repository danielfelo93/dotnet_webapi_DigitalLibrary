using DigitalLibrary.WebApi.Repositories.Contracts;
using DigitalLibrary.WebApi.Repositories.Implementations;

namespace DigitalLibrary.WebApi.Configurations
{
    public static class DependencyInjections
    {
        public static IServiceCollection SetDependencyInjection(this IServiceCollection services)
        { 
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        } 
    }
}
