using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Xamarin.Services.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MvvmPackage.Xamarin.Services
{
    public class MvFormsNavigationService : IMvNavigationService
    {
        private readonly IFormsPageActivatorService _pageActivatorService;
        public MvFormsNavigationService(IFormsPageActivatorService pageActivatorService)
        {
            _pageActivatorService = pageActivatorService;
        }

        public async Task NavigateToAsync<TPageModel>() where TPageModel : PageModelBase
        {
            await NavigateToAsync(_pageActivatorService.CreatePageFromPageModel<TPageModel>());
        }

        public async Task NavigateToAsync<TPageModel, TParameter>(TParameter parameter) where TPageModel : PageModelBase<TParameter>
        {
            await NavigateToAsync(_pageActivatorService.CreatePageFromPageModel<TPageModel, TParameter>(parameter));
        }

        private async Task NavigateToAsync(Page page)
        {
            await Device.InvokeOnMainThreadAsync(() =>
                    Application.Current.MainPage.Navigation?.PushAsync(page)
                );
        }

        public async Task PopAsync()
        {
            await Device.InvokeOnMainThreadAsync(() =>
                   Application.Current.MainPage.Navigation.PopAsync()
               );
        }
    }
}
