using Autofac;
using MvvmPackage.Core;
using NotatnikMechanika.Core.Interfaces;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Resources/Fonts/GoogleSans-Bold.ttf")]
[assembly: ExportFont("Resources/Fonts/GoogleSans-BoldItalic.ttf")]
[assembly: ExportFont("Resources/Fonts/GoogleSans-Italic.ttf")]
[assembly: ExportFont("Resources/Fonts/GoogleSans-Medium.ttf")]
[assembly: ExportFont("Resources/Fonts/GoogleSans-MediumItalic.ttf")]
[assembly: ExportFont("Resources/Fonts/GoogleSans-Regular.ttf")]
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NotatnikMechanika.Forms
{
    public partial class App
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
            if (IoC.Container is null)
            {
                return;
            }

            var authService = IoC.Container.Resolve<IAuthService>();
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