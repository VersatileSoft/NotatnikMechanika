using Blazor.Extensions.Logging;
using Blazored.LocalStorage;
using MatBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MVVMPackage.Blazor;
using NotatnikMechanika.Client.Services;
using NotatnikMechanika.Core;
using NotatnikMechanika.Core.Interfaces;
using System.Net.Http;

namespace NotatnikMechanika.Client
{
    public class Application : BlazorApp<MainPageService, App>
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("NotatnikMechanika.Server", client => client.BaseAddress = BaseAddress);
            services.AddSingleton(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("NotatnikMechanika.Server"));
            services.AddBlazoredLocalStorage();
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            services.AddLogging(builder => builder
                .AddBrowserConsole()
                .SetMinimumLevel(LogLevel.Warning)
            );
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

        protected override void AppStart()
        {
            IAuthService authService = Services.GetService<IAuthService>();
            authService.AuthChanged += (s, e) => ((ApiAuthenticationStateProvider)Services.GetService<AuthenticationStateProvider>()).StateChanged();
        }
    }
}
