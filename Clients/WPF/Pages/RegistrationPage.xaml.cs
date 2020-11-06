using MvvmPackage.Wpf.Pages;
using NotatnikMechanika.Core.PageModels;
using System.Windows.Media.Animation;

namespace NotatnikMechanika.WPF.Pages
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : MvWpfPage<RegistrationPageModel>
    {
      //  private readonly Storyboard _storyboard;

        public RegistrationPage()
        {
            InitializeComponent();
            InitAnimations();
        }

        private void InitAnimations()
        {
            /* DoubleAnimation WithAnimation = new DoubleAnimation
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
            // Storyboard.SetTargetName(TopInputsMargin, TopInput.Name);
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

            // _storyboard.Begin(Logo);*/
        }
    }
}