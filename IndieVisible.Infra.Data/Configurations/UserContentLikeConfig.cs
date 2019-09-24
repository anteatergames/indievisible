using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndieVisible.Infra.Data.Mappings
{
    public class UserContentLikeConfig : IEntityTypeConfiguration<UserContentLike>
    {
        public void Configure(EntityTypeBuilder<UserContentLike> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");


            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");
        }
    }
}
