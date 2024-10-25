using DigitalLibrary.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace DigitalLibrary.WebApi.Configurations;

public static class AuthConfigurations
{
    public static IServiceCollection SetDigitalLibraryAuthconfiguration(this IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 8;

            //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            //options.Lockout.MaxFailedAccessAttempts = 5;
        }
        ).AddEntityFrameworkStores<DigitalLibraryAppDbContext>()
        .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = false,
                //ValidIssuer = "issuer",
                //ValidAudience = "audience",
                //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("clave_secreta")),
                //ClockSkew = TimeSpan.Zero


            };
        });
        return services;
    }
}

