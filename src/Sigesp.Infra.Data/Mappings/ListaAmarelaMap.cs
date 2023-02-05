using System.Data;
using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class ListaAmarelaMap : IEntityTypeConfiguration<ListaAmarela>
    {
        public void Configure(EntityTypeBuilder<ListaAmarela> builder)
        {
            builder.ToTable("ListaAmarela");

            builder
                .HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.RevisaoIpenData)
                .HasDefaultValue("0001-01-01 00:00:00");

            builder.Property(c => c.DataPrisao)
                .HasDefaultValue("0001-01-01 00:00:00");

            builder.Property(c => c.Artigos)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(c => c.Comarca)
                .HasMaxLength(255)
                .IsRequired(false);

           builder.Property(c => c.PenaAno)
                .HasDefaultValue(null)
                .HasMaxLength(4)
                .IsRequired(false);
            
            builder.Property(c => c.PenaMes)
                .HasDefaultValue(null)
                .HasMaxLength(6)
                .IsRequired(false);
            
            builder.Property(c => c.PenaDia)
                .HasDefaultValue(null)
                .HasMaxLength(12)
                .IsRequired(false);

            builder.Property(c => c.AcaoPenal)
                .HasDefaultValue(null)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(c => c.DataPrevisaoBeneficio)
                .HasDefaultValue("0001-01-01 00:00:00");

            builder.Property(c => c.DataProgressao)
                .HasDefaultValue("0001-01-01 00:00:00");

            builder.Property(c => c.DataSaidaPrevista)
                .HasDefaultValue("0001-01-01 00:00:00");

            builder.Property(c => c.PrevisaoBeneficioObservacao)
                .HasDefaultValue(null)
                .HasMaxLength(255)
                .IsRequired(false);
            

            //Campos novos adicionados em 09/02/2022
            builder.Property(c => c.AguardandoTransferencia)
                .HasDefaultValue(false);
            
            builder
                .HasOne(c => c.Detento)
                .WithOne(d => d.ListaAmarela)
                .HasForeignKey<ListaAmarela>(d => d.DetentoId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasIndex(c => c.DetentoId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique();

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}