using Autofac;
using MvvmPackage.Core;
using Xamarin.Forms;

namespace MvvmPackage.Xamarin.Pages
{
    public class MvContentPage<TPageModel> : ContentPage where TPageModel : PageModelBase
    {
        public TPageModel PageModel { get; set; }

        public MvContentPage()
        {
            PageModel = IoC.Container.Resolve<TPageModel>();
            BindingContext = PageModel;
            Appearing += async (s, e) => await PageModel.Initialize().ConfigureAwait(false);
        }
    }
}
