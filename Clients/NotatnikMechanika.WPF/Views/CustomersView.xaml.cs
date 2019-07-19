using MvvmCross.Platforms.Wpf.Views;
using NotatnikMechanika.WPF.Presenters.Attributes;

namespace NotatnikMechanika.WPF.Views
{
    [MasterDetailPage(Position = MasterDetailPageAttribute.MasterDetailPosition.Detail)]
    public partial class CustomersView : MvxWpfView
    {
        public CustomersView()
        {
            InitializeComponent();
        }
    }
}