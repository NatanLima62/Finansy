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
        var id = contextAccessor?.HttpContext?.User.ObterUsuarioId();
        return string.IsNullOrWhiteSpace(id) ? null : int.Parse(id);
    }
    
    public static int? ObterUnidadeId(this IHttpContextAccessor? contextAccessor)
    {
        var unidadeId = contextAccessor?.HttpContext?.User.ObterUnidadeId();
        return string.IsNullOrWhiteSpace(unidadeId) ? null : int.Parse(unidadeId);
    }
    
    public static string ObterNomeUsuario(this IHttpContextAccessor? contextAccessor)
    {
        var nome = contextAccessor?.HttpContext?.User.ObterNomeUsuario();
        return string.IsNullOrWhiteSpace(nome) ? string.Empty : nome;
    }
    
    public static string ObterEmailUsuario(this IHttpContextAccessor? contextAccessor)
    {
        var email = contextAccessor?.HttpContext?.User.ObterEmailUsuario();
        return string.IsNullOrWhiteSpace(email) ? string.Empty : email;
    }
    
    public static string ObterUnidade(this IHttpContextAccessor? contextAccessor)
    {
        var unidade = contextAccessor?.HttpContext?.User.ObterUnidade();
        return string.IsNullOrWhiteSpace(unidade) ? string.Empty : unidade;
    }
}