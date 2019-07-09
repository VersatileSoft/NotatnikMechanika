using MvvmCross.Platforms.Wpf.Views;
using NotatnikMechanika.Core.ViewModels;
using NotatnikMechanika.WPF.Presenters.Attributes;
using System.Windows;
using System.Windows.Media.Animation;

namespace NotatnikMechanika.WPF.Views
{

    [MasterDetailPage(Position = MasterDetailPageAttribute.MasterDetailPosition.Master)]
    public partial class MenuView : MvxWpfView
    {
        public MenuView()
        {
            InitializeComponent();
        }

        bool StateClosed = true;
       
        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            if (StateClosed)
            {
                Storyboard sb = this.FindResource("OpenMenu") as Storyboard;
                sb.Begin();
            }
            else
            {
                Storyboard sb = this.FindResource("CloseMenu") as Storyboard;
                sb.Begin();
            }

            StateClosed = !StateClosed;
        }
    }
}
