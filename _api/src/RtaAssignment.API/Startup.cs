using System.Net;
using RtaAssignment.API.Installers;
using RtaAssignment.Business.Common.Configurations;
using RtaAssignment.Business.Common.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RtaAssignment.API.MappingProfiles;

namespace RtaAssignment.API
{
    public class Startup
    {
        private readonly SwaggerConfigurations _swaggerConfigurations = new SwaggerConfigurations();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuration.GetSection(nameof(SwaggerConfigurations)).Bind(_swaggerConfigurations);
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServiceToAssemble(Configuration);
            services.AddAutoMapper(typeof(DomainToDtoProfile).Assembly);
            services.AddAutoMapper(typeof(DtoToDomainProfile).Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(options => options.RouteTemplate = _swaggerConfigurations.JsonRoute);
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(_swaggerConfigurations.UiEndPoint, _swaggerConfigurations.Name);
                });
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
            }

            //app.UseHttpsRedirection();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index", "Fallback");
            });
        }
    }
}