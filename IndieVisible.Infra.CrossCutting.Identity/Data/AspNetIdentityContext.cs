using IndieVisible.Domain.Core.Enums;
using IndieVisible.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace IndieVisible.Infra.CrossCutting.Identity.Data
{
    public class AspNetIdentityContext : IdentityDbContext<ApplicationUser>
    {
        public AspNetIdentityContext(DbContextOptions<AspNetIdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SeedRoles(builder);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            string[] roles = Enum.GetNames(typeof(Roles));

            foreach (string role in roles)
            {
                builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = role, NormalizedName = role.ToUpper() });
            }
        }
    }
}
