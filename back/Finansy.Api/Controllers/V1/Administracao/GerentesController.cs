using Finansy.Application.Contracts;
using Finansy.Application.Dtos.V1.Gerente;
using Finansy.Application.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Finansy.Api.Controllers.V1.Administracao;

[AllowAnonymous]
[Route("v{version:apiVersion}/[controller]")]
public class GerentesController : MainController
{
    private readonly IGerenteService _gerenteService;
    public GerentesController(INotificator notificator, IGerenteService gerenteService) : base(notificator)
    {
        _gerenteService = gerenteService;
    }
    
    [HttpPost]
    [SwaggerOperation(Summary = "Adicionar um gerente.", Tags = new [] { "Administração - Gerentes" })]
    [ProducesResponseType(typeof(GerenteDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Adicionar([FromBody] AdicionarGerenteDto dto)
    {
        return CreatedResponse("", await _gerenteService.Adicionar(dto));
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualizar um gerente.", Tags = new [] { "Administração - Gerentes" })]
    [ProducesResponseType(typeof(GerenteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarGerenteDto dto)
    {
        return OkResponse(await _gerenteService.Atualizar(id,dto));
    }
    
    [HttpGet("id/{id}")]
    [SwaggerOperation(Summary = "Obter um gerente por id.", Tags = new [] { "Administração - Gerentes" })]
    [ProducesResponseType(typeof(GerenteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ObterPorId(int id)
    {
        return OkResponse(await _gerenteService.ObterPorId(id));
    }
    
    [HttpGet("email/{email}")]
    [SwaggerOperation(Summary = "Obter um gerente por id.", Tags = new [] { "Administração - Gerentes" })]
    [ProducesResponseType(typeof(GerenteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ObterPorEmail(string email)
    {
        return OkResponse(await _gerenteService.ObterPorEmail(email));
    }
    
    [HttpPatch("ativar/{id}")]
    [SwaggerOperation(Summary = "Ativar um gerente.", Tags = new [] { "Administração - Gerentes" })]
    [ProducesResponseType(typeof(GerenteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Ativar(int id)
    {
        await _gerenteService.Ativar(id);
        return OkResponse();
    }
    
    [HttpPatch("desativar/{id}")]
    [SwaggerOperation(Summary = "Desativar um gerente.", Tags = new [] { "Administração - Gerentes" })]
    [ProducesResponseType(typeof(GerenteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Desativar(int id)
    {
        await _gerenteService.Desativar(id);
        return OkResponse();
    }
}