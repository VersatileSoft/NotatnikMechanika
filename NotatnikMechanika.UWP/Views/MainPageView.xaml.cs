using MvvmCross.Platforms.Uap.Views;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace NotatnikMechanika.UWP.Views
{
    public sealed partial class MainPageView : MvxWindowsPage
    {
        public MainPageView()
        {
            InitializeComponent();

            CoreApplicationViewTitleBar CoreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            CoreTitleBar.ExtendViewIntoTitleBar = true;

            Window.Current.SetTitleBar(DragArea);

            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        }
    }
}