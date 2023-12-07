using Finansy.Domain.Entities;

namespace Finansy.Domain.Contracts.Repositories;

public interface IUnidadeRepository : IRepository<Unidade>
{
    void Adicionar(Unidade unidade);
    void Atualizar(Unidade unidade);
    Task<Unidade?> ObterPorId(int id);
}