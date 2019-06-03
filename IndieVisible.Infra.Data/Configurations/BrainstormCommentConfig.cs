using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IndieVisible.Infra.Data.Mappings
{
    public class BrainstormCommentConfig : IEntityTypeConfiguration<BrainstormComment>
    {
        public void Configure(EntityTypeBuilder<BrainstormComment> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(c => c.Text)
                .HasColumnType("nvarchar(1024)")
                .HasMaxLength(1024);
        }
    }
}
