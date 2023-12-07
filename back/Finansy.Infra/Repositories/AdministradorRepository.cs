using Finansy.Domain.Contracts.Repositories;
using Finansy.Domain.Entities;
using Finansy.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finansy.Infra.Repositories;

public class AdministradorRepository: Repository<Administrador>, IAdministradorRepository
{
    public AdministradorRepository(BaseApplicationDbContext context) : base(context)
    {
    }

    public void Adicionar(Administrador usuario)
    {
        Context.Administradores.Add(usuario);
    }

    public void Atualizar(Administrador usuario)
    {
        Context.Administradores.Update(usuario);
    }

    public async Task<Administrador?> ObterPorId(int id)
    {
        return await Context.Administradores.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Administrador?> ObterPorEmail(string email)
    {
        return await Context.Administradores.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(a => a.Email == email);
    }
}