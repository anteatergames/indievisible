using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndieVisible.Infra.Data.Configurations
{
    public class GamificationLevelConfig : IEntityTypeConfiguration<GamificationLevel>
    {
        public void Configure(EntityTypeBuilder<GamificationLevel> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(c => c.Number)
                .IsRequired();

            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.XpToAchieve)
                .IsRequired();
        }
    }
}
