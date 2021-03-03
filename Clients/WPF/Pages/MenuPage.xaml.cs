using MvvmPackage.Wpf.Pages;
using NotatnikMechanika.Core.PageModels;
using NotatnikMechanika.WPF.Pages.Utils;
using System;

namespace NotatnikMechanika.WPF.Pages
{
    public partial class MenuPage : MvWpfPage<MenuPageModel>, IMasterUserControl
    {
        public event EventHandler<MenuButtonClickArgs> MenuButtonClick;

        public MenuPage()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var menuButton = (MenuButton)sender;
            MenuButtonClick?.Invoke(this, new MenuButtonClickArgs
            {
                PageModelType = menuButton.DetailPageModelType,
                Parameter = menuButton.Parameter
            });
        }
    }
}