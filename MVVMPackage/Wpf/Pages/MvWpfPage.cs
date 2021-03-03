using Autofac;
using MvvmPackage.Core;
using System.Windows.Controls;

namespace MvvmPackage.Wpf.Pages
{
    public abstract class MvWpfPage : UserControl
    {
        public PageModelBase PageModel;
    }

    public abstract class MvWpfPage<TPageModel> : MvWpfPage where TPageModel : PageModelBase
    {
        public new TPageModel PageModel
        {
            get => (TPageModel)base.PageModel;
            set => base.PageModel = value;
        }

        protected MvWpfPage()
        {
            PageModel = IoC.Container.Resolve<TPageModel>();
            DataContext = PageModel;
            Loaded += (s, e) => PageModel.Initialize();
        }
    }
}
