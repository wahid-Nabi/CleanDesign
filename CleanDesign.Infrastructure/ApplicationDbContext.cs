using CleanDesign.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanDesign.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            (ApplicationUser user, ApplicationRole role, IdentityUserRole<Guid> userRole) = ApplicationUser.GenerateSuperAdmin();

            builder.Entity<ApplicationUser>(e =>
            {
                e.Property(x => x.Id).HasMaxLength(50);
                e.Property(x => x.UserName).HasMaxLength(50);
                e.Property(x => x.NormalizedUserName).HasMaxLength(50);
                e.Property(x => x.Email).HasMaxLength(50);
                e.Property(x => x.NormalizedEmail).HasMaxLength(50);
                e.Property(x => x.PhoneNumber).HasMaxLength(15);
                e.Property(x => x.ConcurrencyStamp).HasMaxLength(50);
                e.Property(x => x.SecurityStamp).HasMaxLength(50);
                e.Property(x => x.PasswordHash).HasMaxLength(250);
                e.HasData(user);
            });

            builder.Entity<ApplicationRole>(e =>
            {
                e.Property(x => x.Id).HasMaxLength(50);
                e.Property(x => x.Name).HasMaxLength(50);
                e.Property(x => x.NormalizedName).HasMaxLength(50);
                e.HasData(role);
            });

            builder.Entity<IdentityUserRole<Guid>>().HasData(userRole);



            base.OnModelCreating(builder);
        }
    }
}
