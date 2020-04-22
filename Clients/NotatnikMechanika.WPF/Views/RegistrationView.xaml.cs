using MvvmCross.Platforms.Wpf.Views;
using NotatnikMechanika.Core.PageModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace NotatnikMechanika.WPF.Views
{
    /// <summary>
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : MvxWpfView<RegistrationViewModel>
    {
        private Storyboard _storyboard;

        public RegistrationView()
        {
            InitializeComponent();
            InitAnimations();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.CreateUserModel.Password = ((PasswordBox)sender).Password;
        }

        private void RepeatPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.ConfirmPassword = ((PasswordBox)sender).Password;
        }

        private void InitAnimations()
        {
            DoubleAnimation WithAnimation = new DoubleAnimation
            {
                From = 150,
                To = 80,
                Duration = new Duration(TimeSpan.FromMilliseconds(300))
            };

            DoubleAnimation HeightAnimation = new DoubleAnimation
            {
                From = 150,
                To = 80,
                Duration = new Duration(TimeSpan.FromMilliseconds(300))
            };

            ThicknessAnimation TopInputsMargin = new ThicknessAnimation
            {
                From = new Thickness(0, 0, 0, -70),
                To = new Thickness(0, 0, 0, 0),
                Duration = new Duration(TimeSpan.FromMilliseconds(300))
            };

            ThicknessAnimation BottomInputsMargin = new ThicknessAnimation
            {
                From = new Thickness(0, -70, 0, 0),
                To = new Thickness(0, 0, 0, 0),
                Duration = new Duration(TimeSpan.FromMilliseconds(300))
            };

            // Configure the animation to target the button's Width property.
            Storyboard.SetTargetName(WithAnimation, Logo.Name);
            Storyboard.SetTargetName(HeightAnimation, Logo.Name);
            Storyboard.SetTargetName(TopInputsMargin, TopInput.Name);
            Storyboard.SetTargetName(BottomInputsMargin, BottomInput.Name);
            Storyboard.SetTargetProperty(WithAnimation, new PropertyPath(WidthProperty));
            Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath(HeightProperty));
            Storyboard.SetTargetProperty(TopInputsMargin, new PropertyPath(MarginProperty));
            Storyboard.SetTargetProperty(BottomInputsMargin, new PropertyPath(MarginProperty));

            // Create a storyboard to contain the animation.
            _storyboard = new Storyboard();
            _storyboard.Children.Add(WithAnimation);
            _storyboard.Children.Add(HeightAnimation);
            _storyboard.Children.Add(TopInputsMargin);
            _storyboard.Children.Add(BottomInputsMargin);

            _storyboard.Begin(Logo);
        }
    }
}