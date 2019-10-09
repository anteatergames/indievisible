using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndieVisible.Infra.Data.Mappings
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

            builder.Property(x => x.CustomEngineName)
                .HasColumnType("nvarchar(30)")
                .HasMaxLength(30);
        }
    }
}
