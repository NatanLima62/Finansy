using Finansy.Core.Authorization.AuthenticatedUser;
using Finansy.Core.Extensions;
using Finansy.Domain.Contracts.Repositories;
using Finansy.Infra.Contexts;
using Finansy.Infra.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finansy.Infra;

public static class DependencyInjection
{
    public static void DbContextConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        
        services.AddScoped<IAuthenticatedUser>(sp =>
        {
            var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
            
            return httpContextAccessor.UsuarioAutenticado() ? new AuthenticatedUser(httpContextAccessor) : new AuthenticatedUser();
        });
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            options.UseMySql(connectionString, serverVersion);
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });
        
        services.AddDbContext<TenantApplicationDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            options.UseMySql(connectionString, serverVersion);
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });

        services.AddScoped<BaseApplicationDbContext>(serviceProvider =>
        {
            var authenticatedUser = serviceProvider.GetRequiredService<IAuthenticatedUser>();
            if (authenticatedUser is { UsuarioLogado: true, UsuarioComum: true })
            {
                return serviceProvider.GetRequiredService<TenantApplicationDbContext>();
            }
            
            return serviceProvider.GetRequiredService<ApplicationDbContext>();
        });
    }

    public static void ConfigureRepositoriesDependency(this IServiceCollection services)
    {
        services.AddScoped<IAdministradorRepository, AdministradorRepository>();
    }
}