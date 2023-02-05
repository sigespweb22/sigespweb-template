using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class ApplicationNotificationMap : IEntityTypeConfiguration<ApplicationNotification>
    {
        public void Configure(EntityTypeBuilder<ApplicationNotification> builder)
        {
            builder.ToTable("ApplicationNotifications");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Scope)
                .HasDefaultValue(NotificationScopeTypeEnum.NONE);
            
            builder.Property(c => c.SenderUser)
                .HasMaxLength(32)
                .IsRequired(false);
            
            builder.Property(c => c.IsRead)
                .HasDefaultValue(false);
            
            builder.Property(c => c.MessageTitle)
                .IsRequired()
                .HasMaxLength(150);
            
            builder.Property(c => c.MessageBody)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(c => c.MessageDate)
                .IsRequired();
            
            builder.Property(c => c.UserId)
                .IsRequired(false);

            builder
                .HasOne(c => c.ApplicationUser)
                .WithMany(c => c.ApplicationNotifications)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.ApplicationNotifications)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(c => c.TenantId)
                .HasDefaultValue(new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));
        }
    }
}