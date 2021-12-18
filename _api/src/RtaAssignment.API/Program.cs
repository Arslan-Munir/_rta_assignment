using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Identity.Users.SuperAdmin;
using RtaAssignment.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RtaAssignment.Identity.Data;
using RtaAssignment.Identity.Entity;

namespace RtaAssignment.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<IdentityContext>();
                context.Database.Migrate();
                await SeedData(services);
                await host.RunAsync();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occured while starting the application");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }

        private static async Task SeedData(IServiceProvider services)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .Build();

            var unitOfWork = services.GetRequiredService<IUnitOfWorkFactory>();
            using var uow = unitOfWork.Create();
            var seedRoles = Convert.ToBoolean(config.GetSection("SeedConfigurations:SeedRoles").Value);
            if (seedRoles)
            {
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await SeedIdentity.AddRoles(roleManager);
            }

            var seedUsers = Convert.ToBoolean(config.GetSection("SeedConfigurations:SeedUsers").Value);
            if (seedUsers)
            {
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                var users = new List<SuperAdminToRegisterDto>();
                config.GetSection("UsersToSeed").Bind(users);
                await SeedIdentity.AddSuperAdminUsers(userManager, users);
            }

            uow.Commit();
        }
    }
}