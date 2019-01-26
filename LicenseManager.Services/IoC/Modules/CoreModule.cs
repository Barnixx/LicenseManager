using System.Reflection;
using Autofac;
using LicenseManager.Core.Domain;
using Microsoft.AspNetCore.Identity;

namespace LicenseManager.Services.IoC.Modules
{
    public class CoreModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var coreAssembly = Assembly.GetAssembly(typeof(IEntity));
            builder.RegisterAssemblyTypes(coreAssembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            
        }
    }
}