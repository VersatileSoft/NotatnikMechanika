using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace MVVMPackage.Blazor
{
    public abstract class BlazorApp<TMainPageService, TComponent> where TMainPageService : IMainPageService where TComponent : IComponent
    {
        protected IServiceProvider Services { get; set; }
        protected BlazorApp()
        {
            IoC.PlatformProjectAssembly = GetType().Assembly;
            IoC.CoreProjectAssembly = typeof(TMainPageService).Assembly;
            IoC.PlatformPackageProjectAssembly = typeof(BlazorApp<TMainPageService, TComponent>).Assembly;
        }

        protected virtual void ConfigureServices(IServiceCollection builder) { }
        protected virtual void AppStart() { }

        public async Task Build(string[] args)
        {
            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<TComponent>("app");
            builder.ConfigureContainer(new AutofacServiceProviderFactory(IoC.ConfigureServices));
            ConfigureServices(builder.Services);
            builder.Services.AddHttpClient("NotatnikMechanika.Server", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
               // .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("NotatnikMechanika.Server"));

            var app = builder.Build();
            await app.RunAsync();
            Services = app.Services;
            AppStart();
        }
    }
}
