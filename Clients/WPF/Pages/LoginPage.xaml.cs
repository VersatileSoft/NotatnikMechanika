using MvvmPackage.Wpf.Pages;
using NotatnikMechanika.Core.PageModels;

namespace NotatnikMechanika.WPF.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : MvWpfPage<LoginPageModel>
    {
       // private Storyboard _storyboard;
        public LoginPage()
        {
            InitializeComponent();
            InitAnimations();
        }

        private void InitAnimations()
        {
            //DoubleAnimation WithAnimation = new DoubleAnimation
            //{
            //    From = 80,
            //    To = 150,
            //    Duration = new Duration(TimeSpan.FromMilliseconds(300))
            //};

            //DoubleAnimation HeightAnimation = new DoubleAnimation
            //{
            //    From = 80,
            //    To = 150,
            //    Duration = new Duration(TimeSpan.FromMilliseconds(300))
            //};

            //DoubleAnimation OpacityAnimation = new DoubleAnimation
            //{
            //    From = 0,
            //    To = 1,
            //    Duration = new Duration(TimeSpan.FromMilliseconds(300))
            //};



        /*    // Configure the animation to target the button's Width property.
         //   Storyboard.SetTargetName(WithAnimation, Logo.Name);
         //   Storyboard.SetTargetName(HeightAnimation, Logo.Name);
            //Storyboard.SetTargetName(OpacityAnimation, LoginControls.Name);
            Storyboard.SetTargetProperty(WithAnimation, new PropertyPath(WidthProperty));
            Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath(HeightProperty));
            Storyboard.SetTargetProperty(OpacityAnimation, new PropertyPath(OpacityProperty));

            // Create a storyboard to contain the animation.
            _storyboard = new Storyboard();
            _storyboard.Children.Add(WithAnimation);
            _storyboard.Children.Add(HeightAnimation);
            _storyboard.Children.Add(OpacityAnimation);

           // _storyboard.Begin(Logo);*/
        }
    }
}