using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndieVisible.Infra.Data.Configurations
{
    public class FeaturedContentConfig : IEntityTypeConfiguration<FeaturedContent>
    {
        public void Configure(EntityTypeBuilder<FeaturedContent> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(c => c.Title)
                .IsRequired()
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128);

            builder.Property(c => c.Introduction)
                .IsRequired();
        }
    }
}
