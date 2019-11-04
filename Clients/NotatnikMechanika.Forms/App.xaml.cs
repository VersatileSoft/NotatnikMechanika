using MvvmCross.Forms.Core;
using NotatnikMechanika.Forms.Styles;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NotatnikMechanika.Forms
{
    public partial class App : MvxFormsApplication
    {
        private const int smallWightResolution = 768;
        private const int smallHeightResolution = 1280;

        public App()
        {
            InitializeComponent();
            LoadStyles();
        }

        private void LoadStyles()
        {
            if (IsASmallDevice())
            {
                dictionary.MergedDictionaries.Add(SmallDevicesStyle.SharedInstance);
            }
            else
            {
                dictionary.MergedDictionaries.Add(GeneralDevicesStyle.SharedInstance);
            }
        }

        public static bool IsASmallDevice()
        {
            // Get Metrics
            DisplayInfo mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Get resolution
            double width = mainDisplayInfo.Width;
            double height = mainDisplayInfo.Height;

            return width <= smallWightResolution && height <= smallHeightResolution;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}