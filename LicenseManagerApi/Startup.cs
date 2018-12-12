using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using LicenseManagerInfrastructure;
using LicenseManagerInfrastructure.EF;
using LicenseManagerInfrastructure.Extensions;
using LicenseManagerInfrastructure.IoC;
using LicenseManagerInfrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LicenseManagerApi
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

            //AutoFac Configuration
            var builder = new ContainerBuilder(); // AutoFac ContainerBulider
            builder.Populate(services); // Add dotnet component to AutoFac
            builder.RegisterModule(new ContainerModule(Configuration)); // Register ContainerModule
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