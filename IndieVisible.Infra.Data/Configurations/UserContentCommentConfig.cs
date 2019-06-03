using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IndieVisible.Infra.Data.Mappings
{
    public class UserContentCommentConfig : IEntityTypeConfiguration<UserContentComment>
    {
        public void Configure(EntityTypeBuilder<UserContentComment> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");


            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");
        }
    }
}
