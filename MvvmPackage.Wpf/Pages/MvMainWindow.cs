using Autofac;
using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Wpf.Services;
using System.Windows;

namespace MvvmPackage.Wpf.Pages
{
    public class MvMainWindow : Window
    {
        private readonly IMainPageService mainPageService;
        private readonly IWpfPageActivatorService pageActivatorService;

        protected MvMainWindow()
        {
            pageActivatorService = IoC.Container.Resolve<IWpfPageActivatorService>();
            mainPageService = IoC.Container.Resolve<IMainPageService>();
        }

        public void LoadMainPage()
        {
            Content = pageActivatorService.CreatePageFromPageModel(mainPageService.GetMainPageModelType());
        }
    }
}
