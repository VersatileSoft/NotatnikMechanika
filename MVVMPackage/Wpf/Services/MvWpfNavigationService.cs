using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Wpf.Pages;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MvvmPackage.Wpf.Services
{
    public class MvWpfNavigationService : IMvNavigationService
    {
        private readonly NavigationService _navigationService;
        private readonly IWpfPageActivatorService _wpfPageActivatorService;
        public MvWpfNavigationService(IWpfPageActivatorService wpfPageActivatorService)
        {
            _navigationService = ((MvMainWindow)Application.Current.MainWindow).NavigationService;
            _wpfPageActivatorService = wpfPageActivatorService;
        }


        public Task NavigateToAsync<TPageModel>() where TPageModel : PageModelBase
        {
            return NavigateToAsync(_wpfPageActivatorService.CreatePageFromPageModel<TPageModel>());
        }

        public Task NavigateToAsync<TPageModel, TParameter>(TParameter parameter) where TPageModel : PageModelBase<TParameter>
        {
            return NavigateToAsync(_wpfPageActivatorService.CreatePageFromPageModel<TPageModel, TParameter>(parameter));
        }

        private Task NavigateToAsync(ContentControl page)
        {
            _navigationService.Navigate(page);
            return Task.CompletedTask;
        }

        public Task PopAsync()
        {
            _navigationService.GoBack();
            return Task.CompletedTask;
        }
    }
}
