using Autofac;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.MVVMPackage.Attributes;
using Xamarin.MVVMPackage.Services;
using Xamarin.MVVMPackage.Services.Interfaces;

namespace Xamarin.MVVMPackage
{
    public static class IoC
    {
        public static IContainer Container;
        private static readonly ContainerBuilder builder = new ContainerBuilder();

        public static void RegisterTypes()
        {
            // Register services
            builder.RegisterAssemblyTypes(Helpers.CoreAssembly, Helpers.ProjectAssembly)
                .Where(t => t.GetCustomAttribute<SingleInstanceAttribute>() == null)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            // Register singleton services
            // TODO: Find better way to register
            builder.RegisterAssemblyTypes(Helpers.CoreAssembly, Helpers.ProjectAssembly)
                .Where(t => t.GetCustomAttribute<SingleInstanceAttribute>() != null)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .SingleInstance();

            // Register custom services
            builder.RegisterType<NavigationService>().As<INavigationService>();

            // Register page models
            builder.RegisterAssemblyTypes(Helpers.CoreAssembly)
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
