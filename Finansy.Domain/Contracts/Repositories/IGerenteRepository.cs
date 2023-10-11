using Finansy.Domain.Entities;

namespace Finansy.Domain.Contracts.Repositories;

public interface IGerenteRepository : IRepository<Gerente>
{
    void Adicionar(Gerente gerente);
    void Atualizar(Gerente gerente);
    Task<Gerente?> ObterPorId(int id);
    Task<Gerente?> ObterPorEmail(string email);
}