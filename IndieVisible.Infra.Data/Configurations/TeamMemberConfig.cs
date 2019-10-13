using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndieVisible.Infra.Data.Configurations
{
    public class TeamMemberConfig : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(x => x.Leader)
                .HasDefaultValue(false);

            builder.Property(x => x.Role)
                .HasMaxLength(128);

            builder.Property(x => x.Name)
                .HasMaxLength(128);

            builder.Property(x => x.Work);

            builder.Property(x => x.Quote)
                .HasMaxLength(256);

        }
    }
}