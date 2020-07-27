using MvvmPackage.Core;
using MvvmPackage.Wpf.Pages;
using NotatnikMechanika.Core.PageModels;

namespace NotatnikMechanika.WPF.Pages
{
    /// <summary>
    /// Interaction logic for AddCommodityToOrderPage.xaml
    /// </summary> 
    [DisplayDialog]
    public partial class AddCommodityToOrderPage : MvWpfPage<AddCommodityToOrderPageModel>
    {
        public AddCommodityToOrderPage()
        {
            InitializeComponent();
        }
    }
}