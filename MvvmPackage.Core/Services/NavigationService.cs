using System.Threading.Tasks;

namespace Xamarin.MVVMPackage.Services
{
    //public class NavigationService : INavigationService
    //{
    //    public async Task NavigateToAsync<TPageModel>() where TPageModel : PageModelBase
    //    {
    //        await NavigateToAsync(Helpers.CreatePageFromPageModel<TPageModel>());
    //    }

    //    public async Task NavigateToAsync<TPageModel, TParameter>(TParameter parameter) where TPageModel : PageModelBase<TParameter>
    //    {
    //        await NavigateToAsync(Helpers.CreatePageFromPageModel<TPageModel, TParameter>(parameter));
    //    }

    //    private async Task NavigateToAsync(Page page)
    //    {
    //        await Device.InvokeOnMainThreadAsync(() =>
    //                Application.Current.MainPage.Navigation?.PushAsync(page)
    //            );
    //    }

    //    public async Task PopAsync()
    //    {
    //        await Device.InvokeOnMainThreadAsync(() =>
    //               Application.Current.MainPage.Navigation.PopAsync()
    //           );
    //    }

    //    public async Task ReloadMainPage()
    //    {
    //        await Device.InvokeOnMainThreadAsync(() =>
    //              ((MvFormsApplication<IMainPageService>)Application.Current).LoadMainPage()
    //           );
    //    }
    //}
}

