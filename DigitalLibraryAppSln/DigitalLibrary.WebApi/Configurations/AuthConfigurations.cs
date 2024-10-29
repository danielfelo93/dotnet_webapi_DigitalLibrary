using DigitalLibrary.WebApi.Literals;
using DigitalLibrary.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;


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
                ValidateIssuerSigningKey = true,
                //ValidIssuer = "issuer",
                //ValidAudience = "audience",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable(DigitalLibraryLiterals.JWT_KEY)))
                //ClockSkew = TimeSpan.Zero

            };
        });
        return services;
    }
}

