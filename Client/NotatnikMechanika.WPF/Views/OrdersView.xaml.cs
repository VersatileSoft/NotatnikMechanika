using MvvmCross.Platforms.Wpf.Views;
using NotatnikMechanika.WPF.Presenters.Attributes;

namespace NotatnikMechanika.WPF.Views
{
    [MasterDetailPage(Position = MasterDetailPageAttribute.MasterDetailPosition.Detail)]
    public partial class OrdersView : MvxWpfView
    {
        public OrdersView()
        {
            InitializeComponent();
        }
    }
}