using CleanDesign.Domain.Constants;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CleanDesign.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        [MaxLength(50)]
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        [MaxLength (50)]
        public Guid UpdatedBy { get; set; }
        public bool Deleted { get; set; }

        public static (ApplicationUser, ApplicationRole, IdentityUserRole<Guid>) GenerateSuperAdmin()
        {
            Guid userId = Guid.NewGuid();
            Guid roleId = Guid.NewGuid();

            PasswordHasher<ApplicationUser> hasher = new();

            ApplicationUser user = new()
            {
                Id = userId,
                Name = "Admin User",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "clean.admin@yopmail.com",
                NormalizedEmail = "CLEAN.ADMIN@YOPMAIL.COM",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PhoneNumber = "1234567890",
                CreatedBy = userId,
                UpdatedBy = userId,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                Deleted = false
            };
            user.PasswordHash = hasher.HashPassword(user, "Admin@123");

            ApplicationRole role = new()
            {
                Id = roleId,
                Name = Roles.SuperAdmin,
                NormalizedName = Roles.SuperAdmin.ToUpper(),
                CreatedBy = userId,
                UpdatedBy = userId,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                Deleted = false
            };

            IdentityUserRole<Guid> userRole = new()
            {
                UserId = userId,
                RoleId = roleId
            };

            return (user,role,userRole);
        }
    }

    public class ApplicationRole : IdentityRole<Guid>
    {
        public DateTime CreatedOn { get; set; }
        [MaxLength(50)]
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        [MaxLength(50)]
        public Guid UpdatedBy { get; set; }
        public bool Deleted { get; set; }

    }

}
