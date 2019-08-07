using MvvmCross.Platforms.Wpf.Views;
using NotatnikMechanika.WPF.Presenters.Attributes;

namespace NotatnikMechanika.WPF.Views
{
    /// <summary>
    /// Interaction logic for AddServiceCommodityToOrderView.xaml
    /// </summary>
    [DialogPresentation]
    public partial class AddServiceToOrderView : MvxWpfView
    {
        public AddServiceToOrderView()
        {
            InitializeComponent();
        }
    }
}
