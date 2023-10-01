using Finansy.Domain.Entities;

namespace Finansy.Domain.Contracts.Repositories;

public interface IAdminRepository : IRepository<Admin>
{
    void Add(Admin admin);
    void Update(Admin admin);
    Task<Admin?> GetById(int id);
    Task<Admin?> GetByEmail(string email);
}