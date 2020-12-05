using Autofac;
using MaterialDesignThemes.Wpf;
using MvvmPackage.Core;
using MvvmPackage.Wpf.Services;
using System.Windows;
using System.Windows.Navigation;

namespace MvvmPackage.Wpf.Pages
{
    public abstract class MvMainWindow : Window
    {
        public NavigationService NavigationService { get; protected set; }
        public DialogHost MainDialogHost { get; protected set; }

        protected MvMainWindow()
        {           
            Loaded += MvMainWindow_Loaded;
        }

        private void MvMainWindow_Loaded(object sender, RoutedEventArgs e)
        {                      
            NavigationService.Content = IoC.Container.Resolve<IWpfPageActivatorService>().CreatePageFromPageModel(CoreApplicationBase.Instance.MainPageModelType);
        }
    }
}
