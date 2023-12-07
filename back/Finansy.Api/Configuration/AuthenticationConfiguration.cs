using Finansy.Core.Enums;
using Finansy.Core.Extensions;
using Finansy.Core.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;

namespace Finansy.Api.Configuration;

public static class AuthenticationConfiguration
{
    public static void AddAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var appSettingsSection = configuration.GetSection("JwtSettings");
        services.Configure<JwtSettings>(appSettingsSection);

        var appSettings = appSettingsSection.Get<JwtSettings>();
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.IncludeErrorDetails = true; // <- great for debugging
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = appSettings.Emissor,
                    ValidAudiences = appSettings.Audiences()
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"].ToString();
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/hubs") ||
                                                                   path.StartsWithSegments(
                                                                       $"/{EPathAccess.Private.ToDescriptionString()}")))
                        {
                            context.Token = accessToken.FromBase64();
                        }

                        return Task.CompletedTask;
                    }
                };
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy(ETipoUsuario.Administrador.ToString(), builder =>
            {
                builder
                    .RequireAuthenticatedUser()
                    .RequireClaim("TipoUsuario", ETipoUsuario.Administrador.ToString());
            });

            options.AddPolicy(ETipoUsuario.Comum.ToString(), builder =>
            {
                builder
                    .RequireAuthenticatedUser()
                    .RequireClaim("TipoUsuario", ETipoUsuario.Comum.ToString());
            });
        });

        services
            .AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(appSettings.CaminhoKeys));

        services
            .AddJwksManager()
            .UseJwtValidation();

        services.AddMemoryCache();
        services.AddHttpContextAccessor();
    }

    public static void UseAuthenticationConfig(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}