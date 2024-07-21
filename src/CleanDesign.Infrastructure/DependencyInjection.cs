using CleanDesign.Domain.Entities;
using CleanDesign.Domain.Interfaces;
using CleanDesign.Infrastructure.AuthHelpers;
using CleanDesign.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanDesign.Infrastructure
{
    public static class DependencyInjection
    {
        // create addInfrastructureService Extension Function which will be used to register infrasture services
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add repositories
            services.AddTransient<IAuthRepository,AuthRepository>();
            //services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddDbContext<ApplicationDbContext>
                (options => 
                    options.UseSqlServer(configuration.GetConnectionString("CleanDesignDB"))
                );

            services.AddIdentity<ApplicationUser,ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:AuthSettings:SecretKey"] ?? "")),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddTransient<IAuthHelper, AuthHelper>();

            return services;
        }
    }
}
