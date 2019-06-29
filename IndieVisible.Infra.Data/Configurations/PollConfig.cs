using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IndieVisible.Infra.Data.Mappings
{
    public class PollConfig : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.HasOne(x => x.UserContent)
                .WithMany(x => x.Polls);

            builder.Property(x => x.MultipleChoice)
                .HasDefaultValue(false);

            builder.Property(x => x.UsersCanAddOptions)
                .HasDefaultValue(false);

            builder.Property(x => x.CloseDate)
                .HasColumnType("datetime2");

            builder.Property(x => x.Title)
                .HasMaxLength(256);

            builder.HasMany(x => x.Options)
                .WithOne(x => x.Poll)
                .HasForeignKey(x => x.PollId);
        }
    }
}