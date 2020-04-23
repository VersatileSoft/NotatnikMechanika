using MvvmPackage.Wpf.Pages;
using NotatnikMechanika.Core.PageModels;
using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace NotatnikMechanika.WPF.Pages
{
    // [MvxContentPresentation()]
    public partial class MainPage : MvWpfPage<MainPageModel>
    {
        private readonly DoubleAnimation _showMenuAnimation;
        private readonly DoubleAnimation _hideMenuAnimation;
        private bool _isHide = false;

        public MainPage()
        {
            InitializeComponent();
            _showMenuAnimation = new DoubleAnimation(250, TimeSpan.FromMilliseconds(300));
            _hideMenuAnimation = new DoubleAnimation(60, TimeSpan.FromMilliseconds(300));
        }

        private void MvxWpfPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ActualWidth < 800)
            {
                if (!_isHide)
                {
                    //Master.BeginAnimation(WidthProperty, _hideMenuAnimation);
                    _isHide = true;
                }
            }
            else
            {
                if (_isHide)
                {
                   // Master.BeginAnimation(WidthProperty, _showMenuAnimation);
                    _isHide = false;
                }
            }
        }
    }
}