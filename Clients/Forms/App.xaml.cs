using Autofac;
using MvvmPackage.Core;
using MvvmPackage.Xamarin;
using NotatnikMechanika.Core;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Forms.Styles;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using System.Net.Http;

[assembly: ExportFont("Resources/Fonts/GoogleSans-Bold.ttf")]
[assembly: ExportFont("Resources/Fonts/GoogleSans-BoldItalic.ttf")]
[assembly: ExportFont("Resources/Fonts/GoogleSans-Italic.ttf")]
[assembly: ExportFont("Resources/Fonts/GoogleSans-Medium.ttf")]
[assembly: ExportFont("Resources/Fonts/GoogleSans-MediumItalic.ttf")]
[assembly: ExportFont("Resources/Fonts/GoogleSans-Regular.ttf")]
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NotatnikMechanika.Forms
{
    public partial class App : MvFormsApplication<MainPageService>
    {
        private const int smallWightResolution = 768;
        private const int smallHeightResolution = 1280;

        public App()
        {
            InitializeComponent();
            LoadStyles();
            LoadMainPage();
        }
        protected override void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterInstance(new HttpClient
            {
                BaseAddress = new Uri("https://www.mechanicstoolkit.tk/")
            });
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
            IAuthService authService = IoC.Container.Resolve<IAuthService>();
            authService.AuthChanged += (s, e) => LoadMainPage();
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