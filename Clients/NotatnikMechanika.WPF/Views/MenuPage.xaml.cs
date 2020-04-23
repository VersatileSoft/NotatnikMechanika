using MvvmPackage.Wpf.Pages;
using NotatnikMechanika.Core.PageModels;

namespace NotatnikMechanika.WPF.Pages
{
    //[MasterDetailPage(Position = MasterDetailPageAttribute.MasterDetailPosition.Master)]
    public partial class MenuPage : MvWpfPage<MenuPageModel>
    {
        public MenuPage()
        {
            InitializeComponent();
        }
    }
}