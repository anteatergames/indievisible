using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndieVisible.Infra.Data.Mappings
{
    public class GamificationActionConfig : IEntityTypeConfiguration<GamificationAction>
    {
        public void Configure(EntityTypeBuilder<GamificationAction> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(c => c.Action)
                .IsRequired();

            builder.Property(c => c.ScoreValue)
                .IsRequired();
        }
    }
}
