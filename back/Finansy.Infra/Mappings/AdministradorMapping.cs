using Finansy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finansy.Infra.Mappings;

public class AdministradorMapping : IEntityTypeConfiguration<Administrador>
{
    public void Configure(EntityTypeBuilder<Administrador> builder)
    {
        builder.Property(a => a.Nome)
            .HasMaxLength(120);
        
        builder.Property(a => a.Email)
            .HasMaxLength(120);
        
        builder.Property(a => a.Senha)
            .HasMaxLength(255);
        
        builder.Property(a => a.Telefone)
            .IsRequired(false)
            .HasMaxLength(14);
        
        builder.Property(a => a.Cpf)
            .HasMaxLength(11);
    }
}