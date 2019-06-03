using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndieVisible.Infra.Data.Mappings
{
    public class GamificationConfig : IEntityTypeConfiguration<Gamification>
    {
        public void Configure(EntityTypeBuilder<Gamification> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(c => c.CurrentLevelNumber)
                .IsRequired();

            builder.Property(c => c.XpTotal)
                .IsRequired();

            builder.Property(c => c.XpCurrentLevel)
                .IsRequired();

            builder.Property(c => c.XpToNextLevel)
                .IsRequired();
        }
    }
}
