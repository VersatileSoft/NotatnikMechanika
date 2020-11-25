using Autofac;
using MaterialDesignThemes.Wpf;
using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Wpf.Services;
using System.Windows;
using System.Windows.Navigation;

namespace MvvmPackage.Wpf.Pages
{
    public abstract class MvMainWindow : Window
    {
        private readonly IMainPageService _mainPageService;
        private readonly IWpfPageActivatorService _pageActivatorService;
        public NavigationService NavigationService { get; protected set; }
        public DialogHost MainDialogHost { get; protected set; }

        protected MvMainWindow()
        {
            _pageActivatorService = IoC.Container.Resolve<IWpfPageActivatorService>();
            _mainPageService = IoC.Container.Resolve<IMainPageService>();
        }

        protected void LoadMainPage()
        {
            NavigationService.Content = _pageActivatorService.CreatePageFromPageModel(_mainPageService.MainPageModelType());
        }
    }
}
