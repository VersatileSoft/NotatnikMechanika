using MvvmCross.Platforms.Wpf.Views;
using NotatnikMechanika.Core.ViewModels;
using System.Windows.Controls;

namespace NotatnikMechanika.WPF.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : MvxWpfView<LoginViewModel>
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
           ViewModel.UserModel.Password = ((PasswordBox)sender).Password; 
        }
    }
}
