using MvvmPackage.Xamarin.Pages;
using NotatnikMechanika.Core.PageModels;
using Xamarin.Forms.Xaml;

namespace NotatnikMechanika.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : MvContentPage<OrderPageModel>
    {
        public OrderPage()
        {
            InitializeComponent();
        }
    }
}