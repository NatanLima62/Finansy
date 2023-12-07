using Finansy.Application.Contracts;
using Finansy.Application.Dtos.v1.Administrador;
using Finansy.Application.Notifications;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Finansy.Api.Controllers.V1.Administracao;

[Route("v{version:apiVersion}/[controller]")]
public class AdministradoresController : MainController
{
    private readonly IAdministradorService _administradorService;
    public AdministradoresController(INotificator notificator, IAdministradorService administradorService) : base(notificator)
    {
        _administradorService = administradorService;
    }
    
    [HttpPost]
    [SwaggerOperation(Summary = "Adicionar um administrador.", Tags = new [] { "Administração - Administradores" })]
    [ProducesResponseType(typeof(AdministradorDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Adicionar([FromBody] AdicionarAdministradorDto dto)
    {
        return CreatedResponse("", await _administradorService.Adicionar(dto));
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualizar um administrador.", Tags = new [] { "Administração - Administradores" })]
    [ProducesResponseType(typeof(AdministradorDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarAdministradorDto dto)
    {
        return OkResponse(await _administradorService.Atualizar(id,dto));
    }
    
    [HttpGet("id/{id}")]
    [SwaggerOperation(Summary = "Obter um administrador por id.", Tags = new [] { "Administração - Administradores" })]
    [ProducesResponseType(typeof(AdministradorDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ObterPorId(int id)
    {
        return OkResponse(await _administradorService.ObterPorId(id));
    }
    
    [HttpGet("email/{email}")]
    [SwaggerOperation(Summary = "Obter um administrador por id.", Tags = new [] { "Administração - Administradores" })]
    [ProducesResponseType(typeof(AdministradorDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ObterPorEmail(string email)
    {
        return OkResponse(await _administradorService.ObterPorEmail(email));
    }
    
    [HttpPatch("ativar/{id}")]
    [SwaggerOperation(Summary = "Ativar um administrador.", Tags = new [] { "Administração - Administradores" })]
    [ProducesResponseType(typeof(AdministradorDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Ativar(int id)
    {
        await _administradorService.Ativar(id);
        return OkResponse();
    }
    
    [HttpPatch("desativar/{id}")]
    [SwaggerOperation(Summary = "Desativar um administrador.", Tags = new [] { "Administração - Administradores" })]
    [ProducesResponseType(typeof(AdministradorDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Desativar(int id)
    {
        await _administradorService.Desativar(id);
        return OkResponse();
    }
}