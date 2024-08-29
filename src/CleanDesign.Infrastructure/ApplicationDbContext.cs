using CleanDesign.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanDesign.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Address { get; set; } 
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

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

            builder.Entity<IdentityUserRole<Guid>>().HasData(userRole);

            builder.Entity<ApplicationRole>(e =>
            {
                e.Property(x => x.Id).HasMaxLength(50);
                e.Property(x => x.Name).HasMaxLength(50);
                e.Property(x => x.NormalizedName).HasMaxLength(50);
                e.HasData(role);
            });

            builder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(p => p.Products);

            builder.Entity<Customer>()
                .HasMany(p => p.Orders).
                WithOne(o => o.Customer)
                .HasForeignKey(c=>c.CustomerId);

            builder.Entity<Customer>()
                .HasMany(p => p.Addresses).
                WithOne(o => o.Customer).
                HasForeignKey(a=>a.CustomerId);

            builder.Entity<Product>()
                .HasMany(p=>p.Categories)
                .WithMany(p => p.Products);



            base.OnModelCreating(builder);
        }
    }
}
