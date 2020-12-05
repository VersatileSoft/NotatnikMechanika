using Autofac;
using MvvmPackage.Core;
using MvvmPackage.Xamarin.Services.Interfaces;
using Xamarin.Forms;

namespace MvvmPackage.Xamarin
{
    public abstract class MvFormsApplication<CoreApp> : Application where CoreApp : CoreApplicationBase, new()
    {

        protected MvFormsApplication()
        {
            CoreApplicationBase.CreateApp<CoreApp>(new[]
                { 
                    typeof(MvFormsApplication<CoreApp>).Assembly, 
                    GetType().Assembly
                });
            MainPage = IoC.Container.Resolve<IFormsPageActivatorService>().CreatePageFromPageModel(CoreApplicationBase.Instance.MainPageModelType);
        }

        protected override async void OnStart()
        {
            await CoreApplicationBase.Instance.OnStart();
            base.OnStart();
        }
    }
}
