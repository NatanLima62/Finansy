using Finansy.Application.Contracts;
using Finansy.Application.Dtos.V1.Unidade;
using Finansy.Application.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Finansy.Api.Controllers.V1.Gerencia;

[AllowAnonymous]
[Route("v{version:apiVersion}/[controller]")]
public class UnidadesController : MainController
{
    private readonly IUnidadeService _unidadeService;
    public UnidadesController(INotificator notificator, IUnidadeService unidadeService) : base(notificator)
    {
        _unidadeService = unidadeService;
    }
    
    [HttpPost]
    [SwaggerOperation(Summary = "Adicionar uma unidade.", Tags = new [] { "Gerencia - Unidades" })]
    [ProducesResponseType(typeof(UnidadeDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Adicionar([FromBody] AdicionarUnidadeDto dto)
    {
        return CreatedResponse("", await _unidadeService.Adicionar(dto));
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualizar uma unidade.", Tags = new [] { "Gerencia - Unidades" })]
    [ProducesResponseType(typeof(UnidadeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarUnidadeDto dto)
    {
        return OkResponse(await _unidadeService.Atualizar(id,dto));
    }
    
    [HttpGet("id/{id}")]
    [SwaggerOperation(Summary = "Obter uma unidade por id.", Tags = new [] { "Gerencia - Unidades" })]
    [ProducesResponseType(typeof(UnidadeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ObterPorId(int id)
    {
        return OkResponse(await _unidadeService.ObterPorId(id));
    }
    
    [HttpPatch("ativar/{id}")]
    [SwaggerOperation(Summary = "Ativar uma unidade.", Tags = new [] { "Gerencia - Unidades" })]
    [ProducesResponseType(typeof(UnidadeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Ativar(int id)
    {
        await _unidadeService.Ativar(id);
        return OkResponse();
    }
    
    [HttpPatch("desativar/{id}")]
    [SwaggerOperation(Summary = "Desativar uma unidade.", Tags = new [] { "Gerencia - Unidades" })]
    [ProducesResponseType(typeof(UnidadeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Desativar(int id)
    {
        await _unidadeService.Desativar(id);
        return OkResponse();
    }
}