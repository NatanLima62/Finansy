using Finansy.Application.Contracts;
using Finansy.Application.Dtos.V1.Auth;
using Finansy.Application.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Finansy.Api.Controllers.V1.Administracao;

[AllowAnonymous]
[Route("v{version:apiVersion}/[controller]")]
public class AuthController : BaseController
{
    private readonly IAdministradorAuthService _authService;
    public AuthController(INotificator notificator, IAdministradorAuthService authService) : base(notificator)
    {
        _authService = authService;
    }
    
    [HttpPost("login")]
    [SwaggerOperation(Summary = "Login.", Tags = new [] { "Administração - Autenticação" })]
    [ProducesResponseType(typeof(TokenDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(UnauthorizedObjectResult), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody]  LoginDto dto)
    {
        var token = await _authService.Login(dto);
        return token != null ? OkResponse(token) : Unauthorized(new[] { "Usuário e/ou senha incorretos" });
    }
}