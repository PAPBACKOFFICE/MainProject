using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PAPBackOffice.Areas.Identity;

namespace PAPBackOffice.Data
{
    public class IdentityDatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDatabaseContext(DbContextOptions<IdentityDatabaseContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .ToTable("AspNetUsers", t => t.ExcludeFromMigrations());

            builder.Entity<ApplicationUser>()
                .ToTable("AspNetUserTokens", t => t.ExcludeFromMigrations());

            builder.Entity<ApplicationUser>()
                .ToTable("AspNetUserRoles", t => t.ExcludeFromMigrations());

            builder.Entity<ApplicationUser>()
                .ToTable("AspNetUserLogins", t => t.ExcludeFromMigrations());

            builder.Entity<ApplicationUser>()
                .ToTable("AspNetUserClaims", t => t.ExcludeFromMigrations());

            builder.Entity<ApplicationUser>()
                .ToTable("AspNetRoles", t => t.ExcludeFromMigrations());

            builder.Entity<ApplicationUser>()
                .ToTable("AspNetRoleClaims", t => t.ExcludeFromMigrations());

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
