using Blazor.Extensions.Logging;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MVVMPackage.Blazor;
using NotatnikMechanika.Client.Services;
using NotatnikMechanika.Core;
using NotatnikMechanika.Core.Interfaces;
using System;

namespace NotatnikMechanika.Client
{
    public class Application : BlazorApp<MainPageService, App>
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredLocalStorage();
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            services.AddLogging(builder => builder
                .AddBrowserConsole()
                .SetMinimumLevel(LogLevel.Warning)
            );
        }

        protected override void AppStart()
        {
            IAuthService authService = Services.GetService<IAuthService>();
            authService.AuthChanged += (s, e) => ((ApiAuthenticationStateProvider)Services.GetService<AuthenticationStateProvider>()).StateChanged();
        }
    }
}
