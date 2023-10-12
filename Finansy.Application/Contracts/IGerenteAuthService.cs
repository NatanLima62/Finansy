using Finansy.Application.Dtos.V1.Auth;

namespace Finansy.Application.Contracts;

public interface IGerenteAuthService
{
    Task<TokenDto?> Login(LoginDto dto);
}