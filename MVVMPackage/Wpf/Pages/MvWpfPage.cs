using Autofac;
using MvvmPackage.Core;
using System.Windows.Controls;

namespace MvvmPackage.Wpf.Pages
{
    public class MvWpfPage<TPageModel> : UserControl where TPageModel : PageModelBase
    {
        public TPageModel PageModel;

        public MvWpfPage()
        {
            PageModel = IoC.Container.Resolve<TPageModel>();
            DataContext = PageModel;
            Loaded += (s, e) => PageModel.Initialize();
        }
    }
}
