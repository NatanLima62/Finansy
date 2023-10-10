using Finansy.Domain.Entities;

namespace Finansy.Domain.Contracts.Repositories;

public interface IAdministradorRepository : IRepository<Administrador>
{
    void Adicionar(Administrador usuario);
    void Atualizar(Administrador usuario);
    Task<Administrador?> ObterPorId(int id);
    Task<Administrador?> ObterPorEmail(string email);
}