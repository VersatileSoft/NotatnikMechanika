using MvvmCross.Platforms.Wpf.Views;
using NotatnikMechanika.Core.PageModels.ContentViewModels;
using NotatnikMechanika.Shared.Models.Service;
using NotatnikMechanika.WPF.Presenters.Attributes;
using System.Windows.Controls;

namespace NotatnikMechanika.WPF.Views
{
    /// <summary>
    /// Interaction logic for ServicesView.xaml
    /// </summary>
    [MasterDetailPage(Position = MasterDetailPageAttribute.MasterDetailPosition.Detail)]
    public partial class ServicesView : MvxWpfView
    {
        public ServicesView()
        {
            InitializeComponent();
        }

        private void ListView_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            int id = ((sender as ListView).SelectedItem as ServiceModel).Id;
            (ViewModel as ServicesViewModel).ServiceSelectedCommand.Execute(id);
        }
    }
}