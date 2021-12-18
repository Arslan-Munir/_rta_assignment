using System.Collections.Generic;
using RtaAssignment.Business.Common.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace RtaAssignment.API.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var swaggerConfiguration = new SwaggerConfigurations();
            configuration.GetSection(nameof(SwaggerConfigurations)).Bind(swaggerConfiguration);

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc(swaggerConfiguration.Name, new OpenApiInfo
                {
                    Title = swaggerConfiguration.Title,
                    Description = swaggerConfiguration.Description,
                    Version = swaggerConfiguration.Version
                });

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Jwt Bearer settings",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });

                // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // x.IncludeXmlComments(xmlPath);
            });
        }
    }
}