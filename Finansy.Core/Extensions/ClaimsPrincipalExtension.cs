using System.Security.Claims;

namespace Finansy.Core.Extensions;

public static class ClaimsPrincipalExtension
{
    public static bool UsuarioAutenticado(this ClaimsPrincipal? principal)
    {
        return principal?.Identity?.IsAuthenticated ?? false;
    }

    public static string? ObterUsuarioId(this ClaimsPrincipal? principal) => GetClaim(principal, ClaimTypes.NameIdentifier);
    public static string? ObterUnidadeId(this ClaimsPrincipal? principal) => GetClaim(principal, "UnidadeId");
    public static string? ObterTipoUsuario(this ClaimsPrincipal? principal) => GetClaim(principal, "TipoUsuario");
    public static string? ObterNomeUsuario(this ClaimsPrincipal? principal) => GetClaim(principal, ClaimTypes.Name);
    public static string? ObterEmailUsuario(this ClaimsPrincipal? principal) => GetClaim(principal, ClaimTypes.Email);
    public static string? ObterUnidade(this ClaimsPrincipal? principal) => GetClaim(principal, "Unidade");

    private static string? GetClaim(ClaimsPrincipal? principal, string claimName)
    {
        if (principal == null)
        {
            throw new ArgumentException(null, nameof(principal));
        }

        var claim = principal.FindFirst(claimName);
        return claim?.Value;
    }
}