using Autofac;
using MvvmPackage.Core;
using Xamarin.Forms;

namespace MvvmPackage.Xamarin.Pages
{
    public abstract class MvContentPage : ContentPage
    {
        public PageModelBase PageModel;
    }

    public abstract class MvContentPage<TPageModel> : MvContentPage where TPageModel : PageModelBase
    {
        public new TPageModel PageModel
        {
            get => (TPageModel)base.PageModel;
            set => base.PageModel = value;
        }

        protected MvContentPage()
        {
            PageModel = IoC.Container.Resolve<TPageModel>();
            BindingContext = PageModel;
            Appearing += async (s, e) => await PageModel.Initialize().ConfigureAwait(false);
        }
    }
}
