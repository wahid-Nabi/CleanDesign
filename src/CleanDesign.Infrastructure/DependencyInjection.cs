using CleanDesign.Application.Abstractions;
using CleanDesign.Domain.Entities;
using CleanDesign.Domain.Interfaces;
using CleanDesign.Infrastructure.AuthHelpers;
using CleanDesign.Infrastructure.Repositories;
using CleanDesign.Infrastructure.Services;
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
            //services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddDbContext<ApplicationDbContext>
                (options => 
                    options.UseSqlServer(configuration.GetConnectionString("CleanDesignDB"))
                );

            services.AddIdentity<ApplicationUser,ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;                
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
                        ValidateLifetime = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:AuthSettings:SecretKey"] ?? "")),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            // Add repositories
            services.AddTransient<IAuthRepository,AuthRepository>();
            services.AddTransient<IAuthHelper, AuthHelper>();
            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
