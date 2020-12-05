using Blazor.Extensions.Logging;
using Blazored.LocalStorage;
using MatBlazor;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MvvmPackage.Blazor;
using NotatnikMechanika.Core;
using System.Net.Http;

namespace NotatnikMechanika.Client
{
    public class Application : BlazorApp<MainPageService, App>
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("NotatnikMechanika.Server", client => client.BaseAddress = BaseAddress)
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("NotatnikMechanika.Server"));

            services.AddApiAuthorization();

            services.AddLogging(builder => builder
                .AddBrowserConsole()
                .SetMinimumLevel(LogLevel.Warning)
            );

            services.AddBlazoredLocalStorage();
            services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.TopRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 3000;
            });
        }
    }
}
