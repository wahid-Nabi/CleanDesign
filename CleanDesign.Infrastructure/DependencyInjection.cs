using CleanDesign.Domain.Entities;
using CleanDesign.Domain.Interfaces;
using CleanDesign.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddIdentity<ApplicationUser,ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddScoped<SignInManager<ApplicationUser>>();

            return services;
        }
    }
}
