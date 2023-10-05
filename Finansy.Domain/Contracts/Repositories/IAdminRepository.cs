using Finansy.Domain.Entities;

namespace Finansy.Domain.Contracts.Repositories;

public interface IAdminRepository : IRepository<Usuario>
{
    void Add(Usuario usuario);
    void Update(Usuario usuario);
    Task<Usuario?> GetById(int id);
    Task<Usuario?> GetByEmail(string email);
}