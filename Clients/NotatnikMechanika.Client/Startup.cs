using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using NotatnikMechanika.Client.Services;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.PageModels;
using NotatnikMechanika.Core.Services;
using Xamarin.MVVMPackage.Services.Interfaces;

namespace NotatnikMechanika.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IMvxLog, LogService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ISettingsService, SettingsService>();
            services.AddSingleton<IHttpRequestService, HttpRequestService>();

            services.AddSingleton<LoginPageModel>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
