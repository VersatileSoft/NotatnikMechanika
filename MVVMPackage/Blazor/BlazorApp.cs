using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace MvvmPackage.Blazor
{
    public abstract class BlazorApp<TMainPageService, TComponent> where TMainPageService : IMainPageService where TComponent : IComponent
    {
        protected Uri BaseAddress { get; private set; }
        protected BlazorApp()
        {
            //IoC.PlatformProjectAssembly = GetType().Assembly;
            //IoC.CoreProjectAssembly = typeof(TMainPageService).Assembly;
            //IoC.PlatformPackageProjectAssembly = typeof(BlazorApp<TMainPageService, TComponent>).Assembly;
        }

        protected virtual void ConfigureServices(IServiceCollection builder) { }

        public async Task Build(string[] args)
        {
            CoreApplicationBase.Assemblies = new List<Assembly>
            {
                GetType().Assembly,
                typeof(TMainPageService).Assembly,
                typeof(BlazorApp<TMainPageService, TComponent>).Assembly
            };

            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<TComponent>("app");
            BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            builder.ConfigureContainer(new AutofacServiceProviderFactory(IoC.ConfigureServices));
            ConfigureServices(builder.Services);
            await builder.Build().RunAsync().ConfigureAwait(false);
        }
    }
}
