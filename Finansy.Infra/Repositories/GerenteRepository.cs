using Finansy.Domain.Contracts.Repositories;
using Finansy.Domain.Entities;
using Finansy.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finansy.Infra.Repositories;

public class GerenteRepository : Repository<Gerente>, IGerenteRepository
{
    public GerenteRepository(BaseApplicationDbContext context) : base(context)
    {
    }

    public void Adicionar(Gerente gerente)
    {
        Context.Gerentes.Add(gerente);
    }

    public void Atualizar(Gerente gerente)
    {
        Context.Gerentes.Update(gerente);
    }

    public async Task<Gerente?> ObterPorId(int id)
    {
        return await Context.Gerentes.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<Gerente?> ObterPorEmail(string email)
    {
        return await Context.Gerentes.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(g => g.Email == email);
    }
}