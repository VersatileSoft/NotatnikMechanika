using Autofac;
using MvvmPackage.Core;
using Xamarin.Forms;

namespace MvvmPackage.Xamarin.Pages
{
    public class MvContentPage<TPageModel> : ContentPage where TPageModel : PageModelBase
    {
        public MvContentPage()
        {
            BindingContext = IoC.Container.Resolve<TPageModel>();
        }
    }
}
