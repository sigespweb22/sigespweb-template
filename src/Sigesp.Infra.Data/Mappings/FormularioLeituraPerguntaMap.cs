using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Models;

namespace Sigesp.Infra.Data.Mappings
{
    public class FormularioLeituraPerguntaMap : IEntityTypeConfiguration<FormularioLeituraPergunta>
    {
        public void Configure(EntityTypeBuilder<FormularioLeituraPergunta> builder)
        {
            builder.ToTable("FormularioLeituraPerguntas");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.Pergunta)
                .HasMaxLength(255)
                .IsRequired();
            
            builder.Property(c => c.Ordem)
                .IsRequired();
            
            builder.HasQueryFilter(p => !p.IsDeleted);

            //Relacionamentos
            builder
                .HasOne(c => c.FormularioLeituraPerguntaGrupo)
                .WithMany(c => c.FormularioLeituraPerguntas)
                .HasForeignKey(c => c.FormularioLeituraPerguntaGrupoId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasData(
                new FormularioLeituraPergunta
                {
                    Id = Guid.Parse("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    Pergunta = "Quais são os personagens da história?",
                    Ordem = 1,
                    FormularioLeituraPerguntaGrupoId = Guid.Parse("b6da5dc4-2f08-4dc7-81df-8b1915bfab06")
                },
                new FormularioLeituraPergunta
                {
                    Id = Guid.Parse("e94b5df4-379c-482d-99e0-10e35760d580"),
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    Pergunta = "Em que tempo ocorreu a história do livro?",
                    Ordem = 2,
                    FormularioLeituraPerguntaGrupoId = Guid.Parse("b6da5dc4-2f08-4dc7-81df-8b1915bfab06")
                },
                new FormularioLeituraPergunta
                {
                    Id = Guid.Parse("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    Pergunta = "Você alteraria o final da história? Por quê?",
                    Ordem = 3,
                    FormularioLeituraPerguntaGrupoId = Guid.Parse("b6da5dc4-2f08-4dc7-81df-8b1915bfab06")
                },
                new FormularioLeituraPergunta
                {
                    Id = Guid.Parse("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    Pergunta = "Crie uma frase utilizando adequadamente as palavras : SENÃO e SE NÃO.",
                    Ordem = 4,
                    FormularioLeituraPerguntaGrupoId = Guid.Parse("b6da5dc4-2f08-4dc7-81df-8b1915bfab06")
                },
                new FormularioLeituraPergunta
                {
                    Id = Guid.Parse("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    Pergunta = "Reescreva a frase corretamente: “Na sala a menas meninas ou menos meninos?",
                    Ordem = 5,
                    FormularioLeituraPerguntaGrupoId = Guid.Parse("b6da5dc4-2f08-4dc7-81df-8b1915bfab06")
                }
            );
        }
    }
}