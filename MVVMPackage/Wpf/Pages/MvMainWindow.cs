using Autofac;
using MaterialDesignThemes.Wpf;
using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Wpf.Services;
using System.Windows;
using System.Windows.Navigation;

namespace MvvmPackage.Wpf.Pages
{
    public class MvMainWindow : Window
    {
        private readonly IMainPageService mainPageService;
        private readonly IWpfPageActivatorService pageActivatorService;
        public NavigationService NavigationService { get; set; }
        public DialogHost MainDialogHost { get; set; }

        protected MvMainWindow()
        {
            pageActivatorService = IoC.Container.Resolve<IWpfPageActivatorService>();
            mainPageService = IoC.Container.Resolve<IMainPageService>();
        }

        public void LoadMainPage()
        {
            NavigationService.Content = pageActivatorService.CreatePageFromPageModel(mainPageService.GetMainPageModelType());
        }
    }
}
