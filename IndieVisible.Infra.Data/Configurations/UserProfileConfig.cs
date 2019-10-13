using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndieVisible.Infra.Data.Configurations
{
    public class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(c => c.Name)
                .HasColumnType("nvarchar(64)")
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(c => c.Motto)
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128);

            builder.Property(c => c.Bio)
                .HasColumnType("nvarchar(512)")
                .HasMaxLength(512);

            builder.Property(c => c.StudioName)
                .HasColumnType("nvarchar(64)")
                .HasMaxLength(64);

            builder.Property(c => c.Location)
                .HasColumnType("nvarchar(32)")
                .HasMaxLength(32);

            builder.HasMany(x => x.ExternalLinks);
        }
    }
}
