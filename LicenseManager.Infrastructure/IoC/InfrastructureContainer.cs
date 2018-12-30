using Autofac;
using LicenseManager.Infrastructure.IoC.Modules;
using Microsoft.Extensions.Configuration;

namespace LicenseManager.Infrastructure.IoC
{
    public class InfrastructureContainer : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public InfrastructureContainer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //Register Module
            
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
        }
    }
}