using MvvmCross.Platforms.Wpf.Views;
using NotatnikMechanika.Core.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace NotatnikMechanika.WPF.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : MvxWpfView<LoginViewModel>
    {
        private Storyboard _storyboard;
        public LoginView()
        {
            InitializeComponent();
            InitAnimations();
        }

        private void PasswordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewModel.UserModel.Password = ((PasswordBox)sender).Password;
        }

        private void InitAnimations()
        {
            DoubleAnimation WithAnimation = new DoubleAnimation
            {
                From = 80,
                To = 150,
                Duration = new Duration(TimeSpan.FromMilliseconds(300))
            };

            DoubleAnimation HeightAnimation = new DoubleAnimation
            {
                From = 80,
                To = 150,
                Duration = new Duration(TimeSpan.FromMilliseconds(300))
            };

            DoubleAnimation OpacityAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromMilliseconds(300))
            };



            // Configure the animation to target the button's Width property.
            Storyboard.SetTargetName(WithAnimation, Logo.Name);
            Storyboard.SetTargetName(HeightAnimation, Logo.Name);
            Storyboard.SetTargetName(OpacityAnimation, LoginControls.Name);
            Storyboard.SetTargetProperty(WithAnimation, new PropertyPath(WidthProperty));
            Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath(HeightProperty));
            Storyboard.SetTargetProperty(OpacityAnimation, new PropertyPath(OpacityProperty));

            // Create a storyboard to contain the animation.
            _storyboard = new Storyboard();
            _storyboard.Children.Add(WithAnimation);
            _storyboard.Children.Add(HeightAnimation);
            _storyboard.Children.Add(OpacityAnimation);

            _storyboard.Begin(Logo);
        }
    }
}
