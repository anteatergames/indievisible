using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndieVisible.Infra.Data.Mappings
{
    public class PollOptionConfig : IEntityTypeConfiguration<PollOption>
    {
        public void Configure(EntityTypeBuilder<PollOption> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(x => x.Index)
                .IsRequired()
                .HasDefaultValue(0);


            builder.Property(x => x.Image)
                .HasMaxLength(256);

            builder.Property(x => x.PollId)
                .IsRequired();

            builder.HasOne(x => x.Poll);
        }
    }
}

//public Guid PollId { get; set; }

//public int Index { get; set; }

//public string Text { get; set; }

//public string Image { get; set; }

//public virtual Poll Poll { get; set; }