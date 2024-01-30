using System.Reflection;
using Finansy.Core.Authorization.AuthenticatedUser;
using Finansy.Core.Exceptions;
using Finansy.Domain.Contracts;
using Finansy.Domain.Entities;
using Finansy.Infra.Converters;
using Finansy.Infra.Extensions;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace Finansy.Infra.Contexts;

public abstract class BaseApplicationDbContext : DbContext, IUnitOfWork
{
    protected readonly IAuthenticatedUser AuthenticatedUser;

    protected BaseApplicationDbContext(DbContextOptions options, IAuthenticatedUser authenticatedUser) : base(options)
    {
        AuthenticatedUser = authenticatedUser;
    }

    public DbSet<Administrador> Administradores { get; set; } = null!;
    public DbSet<Unidade> Unidades { get; set; } = null!;

    public async Task<bool> Commit() => await SaveChangesAsync() > 0;

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        ApplyTrackingChanges();
        ApplyTenantChanges();
        return base.SaveChangesAsync(cancellationToken);
    }

    private static void ApplyConfigurations(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<ValidationResult>();
        modelBuilder.ApplyEntityConfiguration();
        modelBuilder.ApplyTrackingConfiguration();
        modelBuilder.ApplyTenantConfiguration();
        modelBuilder.ApplySoftDeleteConfiguration();
    }

    private void ApplyTrackingChanges()
    {
        var entries = ChangeTracker.Entries().Where(e =>
            e.Entity is ITracking && e.State is EntityState.Modified || e.State is EntityState.Added);

        foreach (var entityEntry in entries)
        {
            ((ITracking)entityEntry.Entity).AtualizadoEm = DateTime.Now;
            ((ITracking)entityEntry.Entity).AtualizadoPor = AuthenticatedUser.Id;
            ((ITracking)entityEntry.Entity).AtualizadoPorAdmin = AuthenticatedUser.UsuarioAdministrador;

            if (entityEntry.State != EntityState.Added)
                continue;

            ((ITracking)entityEntry.Entity).CriadoEm = DateTime.Now;
            ((ITracking)entityEntry.Entity).CriadoPor = AuthenticatedUser.Id;
            ((ITracking)entityEntry.Entity).AtualizadoPorAdmin = AuthenticatedUser.UsuarioAdministrador;
        }
    }

    private void ApplyTenantChanges()
    {
        var tenants = ChangeTracker.Entries().Where(e => e.Entity is ITenant && e.State is EntityState.Added).ToList();

        if (tenants.Any() && AuthenticatedUser.UnidadeId <= 0)
        {
            throw new DomainException("User not defined for tenant entity!");
        }

        foreach (var tenant in tenants)
        {
            ((ITenant)tenant.Entity).UnidadeId = AuthenticatedUser.UnidadeId;
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly())
            .HasCharSet("utf8mb4")
            .UseCollation("utf8mb4_0900_ai_ci")
            .UseGuidCollation(string.Empty);

        ApplyConfigurations(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<DateOnly>()
            .HaveConversion<DateOnlyCustomConverter>()
            .HaveColumnType("DATE");

        configurationBuilder
            .Properties<TimeOnly>()
            .HaveConversion<TimeOnlyCustomConverter>()
            .HaveColumnType("TIME");
    }
}