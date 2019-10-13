using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndieVisible.Infra.Data.Configurations
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
