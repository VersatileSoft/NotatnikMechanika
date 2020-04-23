using Autofac;
using MvvmPackage.Core.Attributes;
using System.Reflection;

namespace MvvmPackage.Core
{
    public static class IoC
    {
        public static IContainer Container;
        private static readonly ContainerBuilder builder = new ContainerBuilder();

        public static Assembly CoreProjectAssembly { get; set; }
        public static Assembly PlatformProjectAssembly { get; set; }
        public static Assembly PlatformPackageProjectAssembly { get; set; }

        public static void RegisterTypes()
        {
            // Register services
            builder.RegisterAssemblyTypes(CoreProjectAssembly, PlatformProjectAssembly, PlatformPackageProjectAssembly)
                .Where(t => t.GetCustomAttribute<SingleInstanceAttribute>() == null)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            // Register singleton services
            // TODO: Find better way to register
            builder.RegisterAssemblyTypes(CoreProjectAssembly, PlatformProjectAssembly, PlatformPackageProjectAssembly)
                .Where(t => t.GetCustomAttribute<SingleInstanceAttribute>() != null)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .SingleInstance();

            // Register custom services
            //builder.RegisterType<NavigationService>().As<INavigationService>();

            // Register page models
            builder.RegisterAssemblyTypes(CoreProjectAssembly)
                .Where(t => t.IsSubclassOf(typeof(PageModelBase)))
                .Where(t => t.Name.EndsWith("PageModel"))
                .AsSelf();

            //// Register pages
            //builder.RegisterAssemblyTypes(coreProjectAssemby)
            //    .Where(t => t.IsSubclassOf(typeof(Page)))
            //    .Where(t => t.Name.EndsWith("Page"))
            //    .Named<Page>(t => t.Name);

            Container = builder.Build();
        }
    }
}
