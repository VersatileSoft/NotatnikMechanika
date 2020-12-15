using Blazor.Extensions.Logging;
using Blazored.LocalStorage;
using Material.Blazor;
using Microsoft.AspNetCore.Components;
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
            
            services.AddMBServices(
               animatedNavigationManagerServiceConfiguration: Utilities.GetDefaultAnimatedNavigationServiceConfiguration(),
               toastServiceConfiguration: Utilities.GetDefaultToastServiceConfiguration()
           );
        }

        protected override void AppStart()
        {
            IAuthService authService = Services.GetService<IAuthService>();
            authService.AuthChanged += (s, e) => ((ApiAuthenticationStateProvider)Services.GetService<AuthenticationStateProvider>()).StateChanged();
        }
    }

    public static class Utilities
    {
        public static MBAnimatedNavigationManagerServiceConfiguration GetDefaultAnimatedNavigationServiceConfiguration()
        {
            return new MBAnimatedNavigationManagerServiceConfiguration()
            {
                ApplyAnimation = true,
                AnimationTime = 300
            };
        }


        public static MBToastServiceConfiguration GetDefaultToastServiceConfiguration()
        {
            return new MBToastServiceConfiguration()
            {
                Position = MBToastPosition.TopRight,
                CloseMethod = MBToastCloseMethod.Timeout,
            };
        }
    }
}
