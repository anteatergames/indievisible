using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IndieVisible.Infra.Data.Mappings
{
    public class GameLikeConfig : IEntityTypeConfiguration<GameLike>
    {
        public void Configure(EntityTypeBuilder<GameLike> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(c => c.GameId)
                .IsRequired();
        }
    }
}
