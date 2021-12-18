using RtaAssignment.Business;
using RtaAssignment.Business.Common.Configurations;
using RtaAssignment.Business.Interfaces;
using RtaAssignment.Infrastructure.Components;
using RtaAssignment.Infrastructure.Components.Interfaces;
using RtaAssignment.Infrastructure.Persistence.Dapper;
using RtaAssignment.Infrastructure.Persistence.Interfaces;
using RtaAssignment.Infrastructure.UnitOfWork;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RtaAssignment.Identity.Data;

namespace RtaAssignment.API.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IEmployeeTypeService, EmployeeTypeService>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            InstallUnitOfWork(services);
            InstallRepositories(services);
            InstallComponents(services);

            InstallConfigurations(services, configuration);
            services.AddControllers()
                .AddFluentValidation(options =>
                    options.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        private static void InstallUnitOfWork(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWorkFactory, TransactionScopeUnitOfWorkFactory>();
            services.AddTransient<IUnitOfWork, TransactionScopeUnitOfWork>();
        }

        private static void InstallRepositories(IServiceCollection services)
        {
            services.AddTransient<IIdentityRepository, IdentityRepository>();
            services.AddTransient<IEmployeeTypeRepository, EmployeeTypeRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeePhotoRepository, EmployeePhotoRepository>();
        }

        private static void InstallComponents(IServiceCollection services)
        {
            services.AddSingleton<ICloudinaryComponent, CloudinaryComponent>();
        }

        private static void InstallConfigurations(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CloudinaryConfigurations>(configuration.GetSection(nameof(CloudinaryConfigurations)));
        }
    }
}