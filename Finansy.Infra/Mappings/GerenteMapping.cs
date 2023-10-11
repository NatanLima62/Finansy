using Finansy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finansy.Infra.Mappings;

public class GerenteMapping : IEntityTypeConfiguration<Gerente>
{
    public void Configure(EntityTypeBuilder<Gerente> builder)
    {
        builder.Property(g => g.Nome)
            .HasMaxLength(120);
        
        builder.Property(g => g.Email)
            .HasMaxLength(120);
        
        builder.Property(g => g.Senha)
            .HasMaxLength(255);
        
        builder.Property(g => g.Telefone)
            .IsRequired(false)
            .HasMaxLength(14);
        
        builder.Property(g => g.Cpf)
            .HasMaxLength(11);
        
        builder.Property(g => g.Cnpj)
            .IsRequired(false)
            .HasMaxLength(14);
    }
}