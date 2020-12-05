using Autofac;
using MvvmPackage.Core.Attributes;
using System;
using System.Reflection;

namespace MvvmPackage.Core
{
    public static class IoC
    {
        public static IContainer Container;
        private static readonly ContainerBuilder Builder = new ContainerBuilder();

        public static void RegisterTypes(Action<ContainerBuilder> registerCustomTypes = null)
        {
            ConfigureServices(Builder);
            registerCustomTypes?.Invoke(Builder);
            Container = Builder.Build();
        }

        public static void ConfigureServices(ContainerBuilder builder)
        {
            // Register services
            builder.RegisterAssemblyTypes(CoreApplicationBase.Assemblies.ToArray())
                .Where(t => t.GetCustomAttribute<SingleInstanceAttribute>() == null)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            // Register singleton services
            // TODO: Find better way to register
            //builder.RegisterAssemblyTypes(CoreProjectAssembly, PlatformProjectAssembly, PlatformPackageProjectAssembly)
            //    .Where(t => t.GetCustomAttribute<SingleInstanceAttribute>() != null)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces()
            //    .SingleInstance();

            // Register custom services
            //builder.RegisterType<NavigationService>().As<INavigationService>();

            // Register page models
            builder.RegisterAssemblyTypes(CoreApplicationBase.Assemblies.ToArray())
                .Where(t => t.IsSubclassOf(typeof(PageModelBase)))
                .Where(t => t.Name.EndsWith("PageModel"))
                .AsSelf();
        }
    }
}
