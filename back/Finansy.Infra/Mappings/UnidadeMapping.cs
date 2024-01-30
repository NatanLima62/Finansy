using Finansy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finansy.Infra.Mappings;

public class UnidadeMapping : IEntityTypeConfiguration<Unidade>
{
    public void Configure(EntityTypeBuilder<Unidade> builder)
    {
        builder.Property(u => u.Nome)
            .HasMaxLength(120);
        
        builder.Property(u => u.Telefone)
            .IsRequired(false)
            .HasMaxLength(14);
        
        builder.Property(u => u.Nire)
            .IsRequired(false)
            .HasMaxLength(11);
        
        builder.Property(u => u.Cep)
            .HasMaxLength(8);
        
        builder.Property(u => u.Logradouro)
            .HasMaxLength(120);
        
        builder.Property(u => u.Complemento)
            .IsRequired(false)
            .HasMaxLength(120);
        
        builder.Property(u => u.Bairro)
            .HasMaxLength(120);
        
        builder.Property(u => u.Cidade)
            .HasMaxLength(120);
        
        builder.Property(u => u.Estado)
            .HasMaxLength(120);
        
        builder.Property(u => u.AdministradorId)
            .IsRequired();
        
        builder
            .HasOne(u => u.Administrador)
            .WithMany(g => g.Unidades)
            .HasForeignKey(g => g.AdministradorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}