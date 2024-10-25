using DigitalLibrary.WebApi.Literals;
using DigitalLibrary.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.WebApi.Configurations
{
    public static class DbConfigurations
    {
        public static IServiceCollection SetDatabaseConfiguration(this IServiceCollection services)
        {
            //var connectionString = Environment.GetEnvironmentVariable(DigitalLibraryLiterals.CONNECTION_STRING);
            var connectionString = "Server=localhost,14330;Database=DigitalLibraryAppDb;User Id=sa;Password=Daniel193013;TrustServerCertificate=True;";
            services.AddDbContext<DigitalLibraryAppDbContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
    }
}
