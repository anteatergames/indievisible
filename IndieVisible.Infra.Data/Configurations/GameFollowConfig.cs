using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IndieVisible.Infra.Data.Mappings
{
    public class GameFollowConfig : IEntityTypeConfiguration<GameFollow>
    {
        public void Configure(EntityTypeBuilder<GameFollow> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(c => c.GameId)
                .IsRequired();
        }
    }
}
