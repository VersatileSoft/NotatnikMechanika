using MvvmPackage.Core;
using MvvmPackage.Wpf.Pages;
using NotatnikMechanika.Core.PageModels;

namespace NotatnikMechanika.WPF.Pages
{
    /// <summary>
    /// Interaction logic for AddServiceCommodityToOrderPage.xaml
    /// </summary>
    [DisplayDialog]
    public partial class AddServiceToOrderPage : MvWpfPage<AddServiceToOrderPageModel>
    {
        public AddServiceToOrderPage()
        {
            InitializeComponent();
        }
    }
}