using Microsoft.AspNetCore.Components.Builder;
using Microsoft.AspNetCore.Components.Layouts;
using Microsoft.Extensions.DependencyInjection;
using MvvmCross.Navigation;
using NotatnikMechanika.Client.Services;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Core.ViewModels;

namespace NotatnikMechanika.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMvxNavigationService, NavigationService>();
            services.AddSingleton<ISettingsService, SettingsService>();
            services.AddSingleton<IHttpRequestService, HttpRequestService>();

            services.AddSingleton<LoginViewModel>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
