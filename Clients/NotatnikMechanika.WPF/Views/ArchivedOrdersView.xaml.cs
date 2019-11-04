using MvvmCross.Platforms.Wpf.Views;
using NotatnikMechanika.Core.Models;
using NotatnikMechanika.Core.ViewModels;
using NotatnikMechanika.WPF.Presenters.Attributes;
using System.Windows;
using System.Windows.Controls;

namespace NotatnikMechanika.WPF.Views
{
    /// <summary>
    /// Interaction logic for ArchivedOrdersView.xaml
    /// </summary>
    [MasterDetailPage(Position = MasterDetailPageAttribute.MasterDetailPosition.Detail)]
    public partial class ArchivedOrdersView : MvxWpfView
    {
        public ArchivedOrdersView()
        {
            InitializeComponent();
        }

        private void ListView_Selected(object sender, RoutedEventArgs e)
        {
            OrderExtendedModel model = (sender as ListView).SelectedItem as OrderExtendedModel;
            (ViewModel as ArchivedOrdersViewModel).ArchivedOrderSelectedCommand.Execute(model);
        }
    }
}