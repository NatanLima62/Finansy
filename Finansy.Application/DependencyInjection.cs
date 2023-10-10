using System.Reflection;
using Finansy.Infra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finansy.Application;

public static class DependencyInjection
{
    // public static void SetupSettings(this IServiceCollection services, IConfiguration configuration)
    // {
    //     services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
    //     services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
    //     services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
    //     services.Configure<UploadSettings>(configuration.GetSection("UploadSettings"));
    //     services.Configure<DistributedTracingOptions>(configuration.GetSection("DistributedTracing"));
    // }

    public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.DbContextConfig(configuration);

        services.ConfigureRepositoriesDependency();

        services
            .AddAutoMapper(Assembly.GetExecutingAssembly());
    }

    // public static void AddServices(this IServiceCollection services)
    // {
    //     s
    // }

    // public static void UseStaticFileConfiguration(this IApplicationBuilder app, IConfiguration configuration)
    // {
    //     var uploadSettings = configuration.GetSection("UploadSettings");
    //     var publicBasePath = uploadSettings.GetValue<string>("PublicBasePath");
    //     var privateBasePath = uploadSettings.GetValue<string>("PrivateBasePath");
    //
    //     app.UseStaticFiles(new StaticFileOptions
    //     {
    //         FileProvider = new PhysicalFileProvider(publicBasePath),
    //         RequestPath = $"/{EPathAccess.Public.ToDescriptionString()}"
    //     });
    //
    //     app.UseStaticFiles(new StaticFileOptions
    //     {
    //         FileProvider = new PhysicalFileProvider(privateBasePath),
    //         RequestPath = $"/{EPathAccess.Private.ToDescriptionString()}",
    //         OnPrepareResponse = ctx =>
    //         {
    //             if (ctx.Context.User.UsuarioAutenticado()) return;
    //
    //             // respond HTTP 401 Unauthorized.
    //             ctx.Context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
    //             ctx.Context.Response.ContentLength = 0;
    //             ctx.Context.Response.Body = Stream.Null;
    //             ctx.Context.Response.Headers.Add("Cache-Control", "no-store");
    //         }
    //     });
    // }
}