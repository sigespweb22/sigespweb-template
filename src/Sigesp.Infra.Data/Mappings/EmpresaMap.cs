using System.Dynamic;
using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sigesp.Infra.Data.Mappings
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas");

            builder
                .HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder
                .HasMany(c => c.EmpresaConvenios)
                .WithOne(d => d.Empresa)
                .HasForeignKey(c => c.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasMany(c => c.ContasCorrentes)
                .WithOne(c => c.Empresa)
                .HasForeignKey(c => c.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.RazaoSocial)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.NomeFantasia)
                .HasMaxLength(255);
            
            builder.Property(c => c.Cnpj)
                .HasMaxLength(14);
            
            builder.Property(c => c.Cep)
                .HasDefaultValue(0)
                .HasMaxLength(8);
            
            builder.Property(c => c.Cidade)
                .HasMaxLength(50);

            builder.Property(c => c.Estado)
                .HasMaxLength(50);
            
            builder.Property(c => c.Logradouro)
                .IsRequired(false)
                .HasMaxLength(150);
            
            builder.Property(c => c.Numero)
                .IsRequired(false)
                .HasMaxLength(10); 
            
            builder.Property(c => c.Bairro)
                .IsRequired(false)
                .HasMaxLength(50);
            
            builder.Property(c => c.Responsavel)
                .IsRequired(false)
                .HasMaxLength(255);
            
            builder.Property(c => c.Email)
                .IsRequired(false)
                .HasMaxLength(100);
            
            builder.Property(c => c.TelefoneFixo)
                .HasMaxLength(14)
                .IsRequired(false);
            
            builder.Property(c => c.TelefoneCelular)
                .IsRequired(false)
                .HasMaxLength(14);
            
            builder.Property(c => c.WhatsApp)
                .IsRequired(false)
                .HasMaxLength(14);

            builder.HasQueryFilter(p => !p.IsDeleted);

            //Seed for dev
            // builder.HasData(
            //     new Empresa
            //     {
            //         Id = Guid.Parse("00e08a3e-da29-4493-8786-65c67a98970f"),
            //         RazaoSocial = "RBX Alimentos",
            //         NomeFantasia = "RBX",
            //         Cnpj = "12345678912345",
            //         Cep = 12345678,
            //         Cidade = "Criciúma",
            //         Estado = "Santa Catarina",
            //         Logradouro = "Rua teste",
            //         Numero = "10",
            //         Bairro = "Comerciário",
            //         Responsavel = "João da silva",
            //         TelefoneFixo = "12345678912345",
            //         TelefoneCelular = "12345678912345",
            //         WhatsApp = "12345678912345",
            //         CreatedAt = DateTime.Now,
            //         CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
            //         UpdatedAt = DateTime.Now,
            //         UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888")
            //     },
            //     new Empresa
            //     {
            //         Id = Guid.Parse("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
            //         RazaoSocial = "ESAF Ferragens",
            //         NomeFantasia = "ESAF",
            //         Cnpj = "12345678912345",
            //         Cep = 12345678,
            //         Cidade = "Urussanga",
            //         Estado = "Santa Catarina",
            //         Logradouro = "Rua teste",
            //         Numero = "20",
            //         Bairro = "Urussanguinha",
            //         Responsavel = "Geraldo Fornazza",
            //         TelefoneFixo = "12345678912345",
            //         TelefoneCelular = "12345678912345",
            //         WhatsApp = "12345678912345",
            //         CreatedAt = DateTime.Now,
            //         CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
            //         UpdatedAt = DateTime.Now,
            //         UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888")
            //     }
            // );
        }
    }
}