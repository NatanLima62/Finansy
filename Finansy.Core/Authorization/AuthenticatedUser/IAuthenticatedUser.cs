namespace Finansy.Core.Authorization.AuthenticatedUser;

public interface IAuthenticatedUser
{
    public int Id { get; }
    public int UnidadeId { get; }
    public string Nome { get; }
    public string Email { get; }
    public string Unidade { get; }
    public bool UsuarioLogado { get; }
}