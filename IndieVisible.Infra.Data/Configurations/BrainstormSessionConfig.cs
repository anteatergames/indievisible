using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndieVisible.Infra.Data.Mappings
{
    public class BrainstormSessionConfig : IEntityTypeConfiguration<BrainstormSession>
    {
        public void Configure(EntityTypeBuilder<BrainstormSession> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(c => c.Title)
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128);

            builder.Property(c => c.Description)
                .HasColumnType("nvarchar(1024)")
                .HasMaxLength(1024);
        }
    }
}
