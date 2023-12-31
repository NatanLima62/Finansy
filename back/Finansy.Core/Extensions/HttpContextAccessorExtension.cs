using Finansy.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace Finansy.Core.Extensions;

public static class HttpContextAccessorExtension
{
    public static bool UsuarioAutenticado(this IHttpContextAccessor? contextAccessor)
    {
        return contextAccessor?.HttpContext?.User.UsuarioAutenticado() ?? false;
    }
    
    public static int? ObterUsuarioId(this IHttpContextAccessor? contextAccessor)
    {
        var id = contextAccessor?.HttpContext?.User.ObterUsuarioId() ?? string.Empty;
        return string.IsNullOrWhiteSpace(id) ? null : int.Parse(id);
    }
    
    public static int? ObterUnidadeId(this IHttpContextAccessor? contextAccessor)
    {
        var unidadeId = contextAccessor?.HttpContext?.User.ObterUnidadeId() ?? string.Empty;
        return string.IsNullOrWhiteSpace(unidadeId) ? null : int.Parse(unidadeId);
    }
    
    public static string ObterNomeUsuario(this IHttpContextAccessor? contextAccessor)
    {
        var nome = contextAccessor?.HttpContext?.User.ObterNomeUsuario() ?? string.Empty;
        return string.IsNullOrWhiteSpace(nome) ? string.Empty : nome;
    }
    
    public static string ObterEmailUsuario(this IHttpContextAccessor? contextAccessor)
    {
        var email = contextAccessor?.HttpContext?.User.ObterEmailUsuario() ?? string.Empty;
        return string.IsNullOrWhiteSpace(email) ? string.Empty : email;
    }
    
    public static string ObterUnidade(this IHttpContextAccessor? contextAccessor)
    {
        var unidade = contextAccessor?.HttpContext?.User.ObterUnidade() ?? string.Empty;
        return string.IsNullOrWhiteSpace(unidade) ? string.Empty : unidade;
    }
    
    public static ETipoUsuario? ObterTipoUsuario(this IHttpContextAccessor? contextAccessor)
    {
        var tipo = contextAccessor?.HttpContext?.User?.ObterTipoUsuario() ?? string.Empty;
        return string.IsNullOrWhiteSpace(tipo) ? null : Enum.Parse<ETipoUsuario>(tipo);
    }
    
    public static bool EhAdministrador(this IHttpContextAccessor? contextAccessor)
    {
        return ObterTipoUsuario(contextAccessor) is ETipoUsuario.Administrador;
    }
}