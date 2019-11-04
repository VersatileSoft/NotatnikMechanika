using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using NotatnikMechanika.Core.ViewModels;

namespace NotatnikMechanika.Forms.Views
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Root, WrapInNavigationPage = false, NoHistory = true)]
    public partial class MainPageView : MvxMasterDetailPage<MainPageViewModel>
    {
        public MainPageView()
        {
            InitializeComponent();
        }
    }
}