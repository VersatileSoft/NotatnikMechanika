using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using NotatnikMechanika.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotatnikMechanika.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Detail, NoHistory = true)]
    public partial class RegularClientsView : MvxContentPage<RegularClientsViewModel>
    {
        public RegularClientsView()
        {
            InitializeComponent();
        }
    }
}