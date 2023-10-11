﻿// <auto-generated />
using System;
using Finansy.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Finansy.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");
            MySqlModelBuilderExtensions.UseGuidCollation(modelBuilder, "");

            modelBuilder.Entity("Finansy.Domain.Entities.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AtualizadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("int");

                    b.Property<bool>("AtualizadoPorAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<bool>("CriadoPorAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<bool>("Desativado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.HasKey("Id");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("Finansy.Domain.Entities.Gerente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AtualizadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("int");

                    b.Property<bool>("AtualizadoPorAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Cnpj")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<bool>("CriadoPorAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<bool>("Desativado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.HasKey("Id");

                    b.ToTable("Gerentes");
                });

            modelBuilder.Entity("Finansy.Domain.Entities.Unidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AtualizadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("int");

                    b.Property<bool>("AtualizadoPorAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<bool>("CriadoPorAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<bool>("Desativado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("GerenteId")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Nire")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<long>("Numero")
                        .HasColumnType("bigint");

                    b.Property<string>("Telefone")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.HasKey("Id");

                    b.HasIndex("GerenteId");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("Finansy.Domain.Entities.Unidade", b =>
                {
                    b.HasOne("Finansy.Domain.Entities.Gerente", "Gerente")
                        .WithMany("Unidades")
                        .HasForeignKey("GerenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gerente");
                });

            modelBuilder.Entity("Finansy.Domain.Entities.Gerente", b =>
                {
                    b.Navigation("Unidades");
                });
#pragma warning restore 612, 618
        }
    }
}
