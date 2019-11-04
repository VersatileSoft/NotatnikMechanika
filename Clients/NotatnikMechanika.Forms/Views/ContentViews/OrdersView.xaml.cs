using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using NotatnikMechanika.Core.ViewModels;

namespace NotatnikMechanika.Forms.Views
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Detail, NoHistory = true)]
    public partial class OrdersView : MvxContentPage<OrdersViewModel>
    {
        public OrdersView()
        {
            InitializeComponent();
        }
    }
}