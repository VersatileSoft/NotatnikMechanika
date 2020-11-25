using Autofac;
using MvvmPackage.Core;
using Xamarin.Forms;

namespace MvvmPackage.Xamarin.Pages
{
    public abstract class MvContentPage<TPageModel> : ContentPage where TPageModel : PageModelBase
    {
        public TPageModel PageModel { get; }

        protected MvContentPage()
        {
            PageModel = IoC.Container.Resolve<TPageModel>();
            BindingContext = PageModel;
            Appearing += async (s, e) => await PageModel.Initialize().ConfigureAwait(false);
        }
    }
}
