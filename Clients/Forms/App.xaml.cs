using Autofac;
using MvvmPackage.Core;
using MvvmPackage.Xamarin;
using NotatnikMechanika.Core;
using NotatnikMechanika.Core.Interfaces;
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
        public App()
        {
            InitializeComponent();
            LoadMainPage();
        }
        protected override void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterInstance(new HttpClient
            {
                BaseAddress = new Uri("https://www.mechanicstoolkit.tk/")
            });
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