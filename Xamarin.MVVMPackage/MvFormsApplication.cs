using Autofac;
using Xamarin.Forms;
using Xamarin.MVVMPackage.Services.Interfaces;

namespace Xamarin.MVVMPackage
{
    public abstract class MvFormsApplication<TMainPageService> : Application where TMainPageService : IMainPageService
    {
        private readonly IMainPageService appStart;

        protected MvFormsApplication()
        {
            Helpers.ProjectAssembly = GetType().Assembly;
            Helpers.CoreAssembly = typeof(TMainPageService).Assembly;
            IoC.RegisterTypes();
            appStart = IoC.Container.Resolve<IMainPageService>();
        }

        public void LoadMainPage()
        {
            MainPage = new NavigationPage(Helpers.CreatePageFromPageModel(appStart.GetMainPageModelType()));
        }
    }
}
