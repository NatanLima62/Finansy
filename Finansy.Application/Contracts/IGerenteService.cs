using Finansy.Application.Dtos.V1.Gerente;

namespace Finansy.Application.Contracts;

public interface IGerenteService
{
    Task<GerenteDto?> Adicionar(AdicionarGerenteDto dto);
    Task<GerenteDto?> Atualizar(int id, AtualizarGerenteDto dto);
    Task<GerenteDto?> ObterPorId(int id);
    Task<GerenteDto?> ObterPorEmail(string email);
    Task Ativar(int id);
    Task Desativar(int id);
}