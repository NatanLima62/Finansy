using Finansy.Application.Dtos.V1.Unidade;

namespace Finansy.Application.Contracts;

public interface IUnidadeService 
{
    Task<UnidadeDto?> Adicionar(AdicionarUnidadeDto dto);
    Task<UnidadeDto?> Atualizar(int id, AtualizarUnidadeDto dto);
    Task<UnidadeDto?> ObterPorId(int id);
    Task Ativar(int id);
    Task Desativar(int id);
}