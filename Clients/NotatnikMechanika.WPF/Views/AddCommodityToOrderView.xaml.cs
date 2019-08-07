using MvvmCross.Platforms.Wpf.Views;
using NotatnikMechanika.WPF.Presenters.Attributes;

namespace NotatnikMechanika.WPF.Views
{
    /// <summary>
    /// Interaction logic for AddCommodityToOrderView.xaml
    /// </summary>
    [DialogPresentation]
    public partial class AddCommodityToOrderView : MvxWpfView
    {
        public AddCommodityToOrderView()
        {
            InitializeComponent();
        }
    }
}
