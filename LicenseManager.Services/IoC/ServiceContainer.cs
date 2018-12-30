using Autofac;
using AutoMapper.Configuration;
using LicenseManager.Services.IoC.Modules;
using LicenseManager.Services.Mappers;

namespace LicenseManager.Services.IoC
{
    public class ServiceContainer : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            //Register Module
            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
            builder.RegisterModule<CoreModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<EventModule>();
        }
    }
}