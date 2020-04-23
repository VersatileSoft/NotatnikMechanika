using Autofac;
using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Xamarin.Services.Interfaces;
using Xamarin.Forms;

namespace MvvmPackage.Xamarin
{
    public abstract class MvFormsApplication<TMainPageService> : Application where TMainPageService : IMainPageService
    {
        private readonly IMainPageService mainPageService;
        private readonly IFormsPageActivatorService pageActivatorService;

        protected MvFormsApplication()
        {
            IoC.PlatformProjectAssembly = GetType().Assembly;
            IoC.CoreProjectAssembly = typeof(TMainPageService).Assembly;
            IoC.PlatformPackageProjectAssembly = typeof(MvFormsApplication<TMainPageService>).Assembly;
            IoC.RegisterTypes();

            pageActivatorService = IoC.Container.Resolve<IFormsPageActivatorService>();
            mainPageService = IoC.Container.Resolve<IMainPageService>();
        }

        public void LoadMainPage()
        {
            MainPage = new NavigationPage(pageActivatorService.CreatePageFromPageModel(mainPageService.GetMainPageModelType()));
        }
    }
}
