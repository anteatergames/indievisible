using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndieVisible.Infra.Data.Configurations
{
    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(c => c.Title)
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(c => c.DeveloperName)
                .HasColumnType("nvarchar(64)")
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnType("nvarchar(max)");

            builder.Property(c => c.CoverImageUrl)
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(c => c.ThumbnailUrl)
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(x => x.CustomEngineName)
                .HasColumnType("nvarchar(30)")
                .HasMaxLength(30);

            builder.HasMany(x => x.ExternalLinks);
        }
    }
}
