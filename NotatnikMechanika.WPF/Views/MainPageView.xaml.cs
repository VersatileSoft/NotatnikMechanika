using MvvmCross.Platforms.Wpf.Views;
using System.Windows;
using System.Windows.Media.Animation;

namespace NotatnikMechanika.WPF.Views
{
    public partial class MainPageView : MvxWpfView
    {
        bool StateClosed = true;
        public MainPageView()
        {
            InitializeComponent();
        }

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
