using Finansy.Application.Dtos.V1.Auth;

namespace Finansy.Application.Contracts;

public interface IAdministradorAuthService
{
    Task<TokenDto?> Login(LoginDto dto);
}