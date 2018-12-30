using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using LicenseManager.Infrastructure.Authentication;
using LicenseManager.Infrastructure.EF;
using LicenseManager.Infrastructure.IoC;
using LicenseManager.Services.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LicenseManager.Api
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; } // Autofac Interface

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add SqlServer service
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<LicenseManagerContext>(options => 
                    options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddJwt();
            services.AddAuthorization(x => x.AddPolicy("admin", p => p.RequireRole("admin")));
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", cors =>
                {
                    cors.WithOrigins("https://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });

            //AutoFac Configuration
            var builder = new ContainerBuilder(); // AutoFac ContainerBulider
            builder.Populate(services); // Add dotnet component to AutoFac
            builder.RegisterModule(new InfrastructureContainer(Configuration));
            builder.RegisterModule(new ServiceContainer());// Register ContainerModule
            ApplicationContainer = builder.Build(); 
            
            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            applicationLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());// Clear AutoFac component after stop application
        }
    }
}