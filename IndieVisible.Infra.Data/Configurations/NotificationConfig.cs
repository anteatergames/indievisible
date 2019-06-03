using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IndieVisible.Infra.Data.Mappings
{
    public class NotificationConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(c => c.Type)
                .IsRequired();

            builder.Property(c => c.Text)
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}
