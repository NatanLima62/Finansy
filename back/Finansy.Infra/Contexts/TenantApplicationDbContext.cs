using Finansy.Core.Authorization.AuthenticatedUser;
using Finansy.Domain.Contracts;
using Finansy.Infra.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Finansy.Infra.Contexts;

public sealed class TenantApplicationDbContext : BaseApplicationDbContext
{
    public TenantApplicationDbContext(DbContextOptions<TenantApplicationDbContext> options, IAuthenticatedUser authenticatedUser) : base(options, authenticatedUser)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyGlobalFilters<ITenant>(t => t.UnidadeId == AuthenticatedUser.UnidadeId);
        base.OnModelCreating(modelBuilder);
    }
}