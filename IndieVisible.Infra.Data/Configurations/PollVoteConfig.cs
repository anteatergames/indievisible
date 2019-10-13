using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndieVisible.Infra.Data.Configurations
{
    public class PollVoteConfig : IEntityTypeConfiguration<PollVote>
    {
        public void Configure(EntityTypeBuilder<PollVote> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");
        }
    }
}