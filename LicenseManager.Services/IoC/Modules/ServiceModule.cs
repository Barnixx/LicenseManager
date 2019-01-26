using System.Reflection;
using Autofac;
using LicenseManager.Core.Domain;
using LicenseManager.Core.Domain.Identity;
using LicenseManager.Core.Domain.Identity.Services;
using LicenseManager.Services.Identity;
using Microsoft.AspNetCore.Identity;

namespace LicenseManager.Services.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(s => s.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();//Life time per Http request
            
            builder.RegisterType<Hasher>()
                .As<IHasher>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<PasswordHasher<User>>().As<IPasswordHasher<User>>();
        }
    }
}