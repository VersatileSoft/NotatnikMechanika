using MvvmPackage.Xamarin.Pages;
using NotatnikMechanika.Core.PageModels;
using Xamarin.Forms.Xaml;

namespace NotatnikMechanika.Forms.Pages.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAccountPage : MvContentPage<MyAccountPageModel>
    {
        public MyAccountPage()
        {
            InitializeComponent();
        }
    }
}