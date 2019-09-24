using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndieVisible.Infra.Data.Mappings
{
    public class UserContentConfig : IEntityTypeConfiguration<UserContent>
    {
        public void Configure(EntityTypeBuilder<UserContent> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(c => c.Title)
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128);

            builder.Property(c => c.Content)
                .IsRequired();

            builder.Property(x => x.Language)
                .HasDefaultValue(SupportedLanguage.English);

            builder.HasMany(x => x.Polls)
                .WithOne(x => x.UserContent)
                .HasForeignKey(x => x.UserContentId);
        }
    }
}
