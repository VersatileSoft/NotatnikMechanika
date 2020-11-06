using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Xamarin.Services.Interfaces;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MvvmPackage.Xamarin.Services
{
    public class MvFormsNavigationService : IMvNavigationService
    {
        private readonly IFormsPageActivatorService _pageActivatorService;

        public event EventHandler<bool> DialogStateChanged;

        public MvFormsNavigationService(IFormsPageActivatorService pageActivatorService)
        {
            _pageActivatorService = pageActivatorService;
        }

        public async Task NavigateToAsync<TPageModel>() where TPageModel : PageModelBase
        {
            await NavigateToAsync(_pageActivatorService.CreatePageFromPageModel<TPageModel>());
        }

        public async Task NavigateToAsync<TPageModel>(int parameter) where TPageModel : PageModelBase
        {
            await NavigateToAsync(_pageActivatorService.CreatePageFromPageModel<TPageModel>(parameter));
        }

        private async Task NavigateToAsync(Page page)
        {
            await Device.InvokeOnMainThreadAsync(() =>
            {
                INavigation x = Application.Current.MainPage.Navigation;
                if (x != null)
                {
                    return x.PushAsync(page);
                }
                else
                {
                    return Task.CompletedTask;
                }
            });
        }

        public async Task PopAsync()
        {
            await Device.InvokeOnMainThreadAsync(() =>
                   Application.Current.MainPage.Navigation.PopAsync()
               );
        }

        public Task CloseDialog()
        {
            throw new System.NotImplementedException();
        }
    }
}
