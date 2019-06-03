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
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            SeedRoles(builder);

        }

        private static void SeedRoles(ModelBuilder builder)
        {
            var roles = Enum.GetNames(typeof(Roles));

            foreach (var role in roles)
            {
                builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = role, NormalizedName = role.ToUpper() });
            }
        }
    }
}
