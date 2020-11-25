using Autofac;
using MvvmPackage.Core;
using System.Windows.Controls;

namespace MvvmPackage.Wpf.Pages
{
    public abstract class MvWpfPage<TPageModel> : UserControl where TPageModel : PageModelBase
    {
        public readonly TPageModel PageModel;

        protected MvWpfPage()
        {
            PageModel = IoC.Container.Resolve<TPageModel>();
            DataContext = PageModel;
            Loaded += (s, e) => PageModel.Initialize();
        }
    }
}
