using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndieVisible.Infra.Data.Configurations
{
    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(x => x.Name)
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .HasMaxLength(512);

            builder.Property(x => x.Motto)
                .HasMaxLength(128);

            builder.Property(x => x.LogoUrl)
                .HasMaxLength(256);

            builder.HasMany(x => x.Members)
                .WithOne(x => x.Team)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}