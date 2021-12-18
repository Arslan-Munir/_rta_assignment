using System;
using System.Text;
using RtaAssignment.Business.Common.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace RtaAssignment.API.Installers
{
    public class JwtInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfigurations = new JwtConfigurations();
            configuration.GetSection(nameof(JwtConfigurations)).Bind(jwtConfigurations);

            services.AddScoped<JwtConfigurations>();
            services.Configure<JwtConfigurations>(configuration.GetSection(nameof(jwtConfigurations)));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfigurations.Secret)),
                ValidateIssuer = true,
                ValidIssuer = jwtConfigurations.Issuer,
                ValidateAudience = true,
                ValidAudience = jwtConfigurations.Audience,
                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddSingleton(tokenValidationParameters);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = tokenValidationParameters;
            });
        }
    }
}