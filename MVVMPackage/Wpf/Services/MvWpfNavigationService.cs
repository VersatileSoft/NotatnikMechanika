using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Wpf.Pages;
using System;
using System.Reflection;
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

        public event EventHandler<bool> DialogStateChanged;

        public MvWpfNavigationService(IWpfPageActivatorService wpfPageActivatorService)
        {
            _navigationService = ((MvMainWindow)Application.Current.MainWindow)?.NavigationService;
            _wpfPageActivatorService = wpfPageActivatorService;
        }

        public Task NavigateToAsync<TPageModel>() where TPageModel : PageModelBase
        {
            return NavigateToAsync<TPageModel>(_wpfPageActivatorService.CreatePageFromPageModel<TPageModel>());
        }

        public Task NavigateToAsync<TPageModel>(int parameter) where TPageModel : PageModelBase
        {
            return NavigateToAsync<TPageModel>(_wpfPageActivatorService.CreatePageFromPageModel<TPageModel>(parameter));
        }

        public Task PopAsync()
        {
            _navigationService.GoBack();
            return Task.CompletedTask;
        }

        public Task CloseDialog()
        {
            SetDialogState(false);
            return Task.CompletedTask;
        }

        private static bool IsDialog<TPageModel>()
        {
            var types = IoC.PlatformProjectAssembly.GetTypes();
            var pageName = typeof(TPageModel).Name.Replace("Model", "");
            var pageType = Array.Find(types, t => t.Name == pageName);
            return pageType?.GetCustomAttribute<DisplayDialogAttribute>() != null;
        }

        private Task NavigateToAsync<TPageModel>(ContentControl page)
        {
            if (IsDialog<TPageModel>())
            {
                SetDialogState(true, page);
                return Task.CompletedTask;
            }

            _navigationService.Navigate(page);
            return Task.CompletedTask;
        }

        private void SetDialogState(bool isOpen, ContentControl page = null)
        {
            if (!(Application.Current.MainWindow is MvMainWindow mainWindow)) return;
            mainWindow.MainDialogHost.DialogContent = page;
            mainWindow.MainDialogHost.IsOpen = isOpen;
            DialogStateChanged?.Invoke(this, isOpen);
        }
    }
}
