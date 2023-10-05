using Finansy.Core.Extensions;
using Microsoft.AspNetCore.Http;

namespace Finansy.Core.Authorization.AuthenticatedUser;

public class AuthenticatedUser : IAuthenticatedUser
{
    public AuthenticatedUser() { }

    public AuthenticatedUser(IHttpContextAccessor httpContextAccessor)
    {
        Id = httpContextAccessor.ObterUsuarioId()!.Value;
        UnidadeId = httpContextAccessor.ObterUnidadeId()!.Value;
        Nome = httpContextAccessor.ObterNomeUsuario();
        Email = httpContextAccessor.ObterEmailUsuario();
        Unidade = httpContextAccessor.ObterUnidade();
    }
    public int Id { get; } = -1;
    public int UnidadeId { get; } = 1;
    public string Nome { get; } = string.Empty;
    public string Email { get; } = string.Empty;
    public string Unidade { get; } = string.Empty;
    public bool UsuarioLogado => Id > 0;
}