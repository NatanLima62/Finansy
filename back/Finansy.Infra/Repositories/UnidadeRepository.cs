using Finansy.Domain.Contracts.Repositories;
using Finansy.Domain.Entities;
using Finansy.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finansy.Infra.Repositories;

public class UnidadeRepository : Repository<Unidade>, IUnidadeRepository
{
    public UnidadeRepository(BaseApplicationDbContext context) : base(context)
    {
    }

    public void Adicionar(Unidade unidade)
    {
        Context.Unidades.Add(unidade);
    }

    public void Atualizar(Unidade unidade)
    {
        Context.Unidades.Update(unidade);
    }

    public Task<Unidade?> ObterPorId(int id)
    {
        return Context.Unidades.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(u => u.Id == id);
    }
}