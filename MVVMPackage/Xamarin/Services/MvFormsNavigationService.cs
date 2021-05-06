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

        public event EventHandler<bool>? DialogStateChanged;

        public MvFormsNavigationService(IFormsPageActivatorService pageActivatorService)
        {
            _pageActivatorService = pageActivatorService;
        }

        public async Task NavigateToAsync<TPageModel>() where TPageModel : PageModelBase
        {
            await NavigateToAsync(_pageActivatorService.CreatePageFromPageModel<TPageModel>()).ConfigureAwait(false);
        }

        public async Task NavigateToAsync<TPageModel>(bool animated) where TPageModel : PageModelBase
        {
            await NavigateToAsync(_pageActivatorService.CreatePageFromPageModel<TPageModel>(), animated).ConfigureAwait(false);
        }

        public async Task NavigateToAsync<TPageModel>(int parameter, bool animated) where TPageModel : PageModelBase
        {
            await NavigateToAsync(_pageActivatorService.CreatePageFromPageModel<TPageModel>(parameter), animated).ConfigureAwait(false);
        }

        private async Task NavigateToAsync(Page page, bool animated = true)
        {
            await Device.InvokeOnMainThreadAsync(() =>
            {
                var navigation = Application.Current.MainPage.Navigation;
                if (navigation != null)
                {
                    return navigation.PushAsync(page, animated);
                }
                else
                {
                    return Task.CompletedTask;
                }
            }).ConfigureAwait(false);
        }

        public async Task PopAsync()
        {
            await Device.InvokeOnMainThreadAsync(() =>
                   Application.Current.MainPage.Navigation.PopAsync()
               ).ConfigureAwait(false);
        }

        public Task CloseDialog()
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync<TPageModel>(int parameter) where TPageModel : PageModelBase
        {
            throw new NotImplementedException();
        }
    }
}
