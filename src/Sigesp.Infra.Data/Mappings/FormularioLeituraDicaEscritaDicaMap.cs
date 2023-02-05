using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Models;

namespace Sigesp.Infra.Data.Mappings
{
    public class FormularioLeituraDicaEscritaDicaMap : IEntityTypeConfiguration<FormularioLeituraDicaEscritaDica>
    {
        public void Configure(EntityTypeBuilder<FormularioLeituraDicaEscritaDica> builder)
        {
            builder.ToTable("FormularioLeituraDicasEscritaDicas");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.Dica)
                .HasMaxLength(255)
                .IsRequired();
            
            builder.Property(c => c.Ordem)
                .IsRequired();
            
            builder.HasQueryFilter(p => !p.IsDeleted);

            //Relacionamentos
            builder
                .HasOne(c => c.FormularioLeituraDicaEscrita)
                .WithMany(c => c.FormularioLeituraDicaEscritaDicas)
                .HasForeignKey(c => c.FormularioLeituraDicaEscritaId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasIndex(c => c.FormularioLeituraDicaEscritaId)
                .IsUnique(false);
            
            builder.HasData(
                new FormularioLeituraDicaEscritaDica
                {
                    Id = Guid.Parse("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    Dica = "A palavra “SENÃO” é uma conjunção opositiva, podendo ser substituída por “DO CONTRÁRIO”.",
                    Ordem = 1,
                    FormularioLeituraDicaEscritaId = Guid.Parse("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b")
                },
                new FormularioLeituraDicaEscritaDica
                {
                    Id = Guid.Parse("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    Dica = "Ex.:Eu estava muito ocupado, SENÃO (do contrário) teria ido à sua festa. Palavra “SE NÃO”indica uma negação,",
                    Ordem = 2,
                    FormularioLeituraDicaEscritaId = Guid.Parse("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b")
                },
                new FormularioLeituraDicaEscritaDica
                {
                    Id = Guid.Parse("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    Dica = "podendo ser substituída por “CASO NÃO”",
                    Ordem = 3,
                    FormularioLeituraDicaEscritaId = Guid.Parse("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b")
                },
                new FormularioLeituraDicaEscritaDica
                {
                    Id = Guid.Parse("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    Dica = "A expressão “SE NÃO” indica uma negação, podendo ser substituída por “CASO NÃO”.",
                    Ordem = 4,
                    FormularioLeituraDicaEscritaId = Guid.Parse("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b")
                },
                new FormularioLeituraDicaEscritaDica
                {
                    Id = Guid.Parse("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    Dica = "Ex.:SE NÃO (caso não) fosse pela chuva, o passeio teria sido ótimo.",
                    Ordem = 5,
                    FormularioLeituraDicaEscritaId = Guid.Parse("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b")
                }
            );
        }
    }
}