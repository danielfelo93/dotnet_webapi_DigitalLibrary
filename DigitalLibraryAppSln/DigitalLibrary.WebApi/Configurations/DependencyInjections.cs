using DigitalLibrary.WebApi.Models;
using DigitalLibrary.WebApi.Repositories.Contracts;
using DigitalLibrary.WebApi.Repositories.Implementations;
using DigitalLibrary.WebApi.Services.Contracts;
using DigitalLibrary.WebApi.Services.Implementations;

namespace DigitalLibrary.WebApi.Configurations
{
    public static class DependencyInjections
    {
        public static IServiceCollection SetDependencyInjection(this IServiceCollection services)
        {
            #region Repository Injection
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBaseRepository<Book>, BaseRepository<Book>>();
            #endregion

            #region Services Injection
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookService, BookService>();
            #endregion

            return services;
        } 
    }
}
