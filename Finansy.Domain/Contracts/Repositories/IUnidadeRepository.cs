using Finansy.Domain.Entities;

namespace Finansy.Domain.Contracts.Repositories;

public interface IUnidadeRepository : IRepository<Unidade>
{
    void Adicionar(Unidade usuario);
    void Atualizar(Unidade usuario);
    Task<Unidade?> ObterPorId(int id);
}