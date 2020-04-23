using Autofac;
using MvvmPackage.Core;
using System.Windows;
using System.Windows.Controls;

namespace MvvmPackage.Wpf.Pages
{
    public class MvWpfPage<TPageModel> : UserControl where TPageModel : PageModelBase
    {
        public MvWpfPage()
        {
            DataContext = IoC.Container.Resolve<TPageModel>();
        }
    }
}
