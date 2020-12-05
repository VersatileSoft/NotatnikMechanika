using Autofac;
using MvvmPackage.Core;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.PageModels;
using NotatnikMechanika.Core.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core
{
    public class CoreApplication : CoreApplicationBase
    {
        public CoreApplication ()
        {
            SetMainPageModel<MainPageModel>();
        }

        protected override void RegisterTypes(ContainerBuilder containerBuilder)
        {
            var httpClient = new HttpClient(new HttpClientMessageHandler())
            {
                BaseAddress = new Uri("https://www.mechanicstoolkit.tk/"),
            };
            containerBuilder.RegisterInstance(httpClient).AsSelf().SingleInstance();
        }

        public override Task OnStart()
        {
            return Task.CompletedTask; // IoC.Container.Resolve<IAuthService>().AuthorizeAsync();
        }
    }
}
