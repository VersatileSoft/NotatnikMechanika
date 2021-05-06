using Autofac;
using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Xamarin.Services.Interfaces;
using Xamarin.Forms;

namespace MvvmPackage.Xamarin
{
    public abstract class MvFormsApplication<TMainPageService> : Application where TMainPageService : IMainPageService
    {
        private readonly IMainPageService? _mainPageService;
        private readonly IFormsPageActivatorService? _pageActivatorService;

        protected MvFormsApplication()
        {
            IoC.PlatformProjectAssembly = GetType().Assembly;
            IoC.CoreProjectAssembly = typeof(TMainPageService).Assembly;
            IoC.PlatformPackageProjectAssembly = typeof(MvFormsApplication<TMainPageService>).Assembly;
            IoC.RegisterTypes(RegisterTypes);

            if (IoC.Container is null)
            {
                return;
            }

            _pageActivatorService = IoC.Container.Resolve<IFormsPageActivatorService>();
            _mainPageService = IoC.Container.Resolve<IMainPageService>();
        }

        protected virtual void RegisterTypes(ContainerBuilder builder) { }

        public void LoadMainPage()
        {
            if (_pageActivatorService is null || _mainPageService is null)
            {
                return;
            }

            var page = _pageActivatorService.CreatePageFromPageModel(_mainPageService.MainPageModelType());
            MainPage = page is Shell ? page : new NavigationPage(page);
        }
    }
}
