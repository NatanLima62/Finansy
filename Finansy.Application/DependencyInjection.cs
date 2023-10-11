using System.Reflection;
using Finansy.Application.Contracts;
using Finansy.Application.Notifications;
using Finansy.Application.Services;
using Finansy.Domain.Entities;
using Finansy.Infra;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScottBrady91.AspNetCore.Identity;

namespace Finansy.Application;

public static class DependencyInjection
{
    public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.DbContextConfig(configuration);

        services.ConfigureRepositoriesDependency();

        services
            .AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services
            .AddScoped<IPasswordHasher<Administrador>, Argon2PasswordHasher<Administrador>>();

    }

    public static void AddServices(this IServiceCollection services)
    {
        services
            .AddScoped<INotificator, Notificator>();
        
        services
            .AddScoped<IAdministradorService, AdministradorService>();
    }
}
