using System.Reflection;
using Autofac;
using LicenseManagerInfrastructure.EF;
using LicenseManagerInfrastructure.Extensions;
using Microsoft.Extensions.Configuration;

namespace LicenseManagerInfrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration; // Get configuration
        
        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<SqlServerSettings>())
                .SingleInstance();
        }
    }
}