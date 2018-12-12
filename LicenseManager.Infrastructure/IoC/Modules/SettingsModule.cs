using Autofac;
using LicenseManager.Infrastructure.EF;
using LicenseManager.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;

namespace LicenseManager.Infrastructure.IoC.Modules
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