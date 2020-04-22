using Autofac;
using Xamarin.Forms;

namespace Xamarin.MVVMPackage.Pages.Xamarin
{
    public class MvContentPage<TPageModel> : ContentPage where TPageModel : PageModelBase
    {
        public MvContentPage()
        {
            BindingContext = IoC.Container.Resolve<TPageModel>();
        }
    }
}
