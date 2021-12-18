using RtaAssignment.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RtaAssignment.Identity.Data;
using RtaAssignment.Identity.Entity;

namespace RtaAssignment.API.Installers
{
    public class IdentityInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("PostgreSQLConnection")).UseLowerCaseNamingConvention());

            services.AddDefaultIdentity<AppUser>(config =>
                {
                    config.Password.RequireDigit = true;
                    config.Password.RequireLowercase = true;
                    config.Password.RequireUppercase = true;
                    config.Password.RequireNonAlphanumeric = true;
                    config.Password.RequiredLength = 8;

                    config.User.RequireUniqueEmail = true;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            ConnectionFactory.ConnectionString = configuration.GetConnectionString("PostgreSQLConnection");
        }
    }
}