using Autofac;
using MvvmPackage.Core;
using System.Windows.Controls;

namespace MvvmPackage.Wpf.Pages
{
    public class MvWpfPage<TPageModel> : UserControl where TPageModel : PageModelBase
    {
        protected TPageModel PageModel;

        public MvWpfPage()
        {
            PageModel = IoC.Container.Resolve<TPageModel>();
            DataContext = PageModel;
        }
    }
}
