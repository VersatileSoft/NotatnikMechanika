using MvvmCross.Forms.Core;
using NotatnikMechanika.Forms.Views;
using Xamarin.Forms;

namespace NotatnikMechanika.Forms
{
    public partial class App : MvxFormsApplication
    {
        public App()
        {
            InitializeComponent();
<<<<<<< HEAD
=======

            switch (Device.RuntimePlatform)
            {
                case Device.WPF:
                    MainPage = new DashboardView();
                    break;
                default:
                    MainPage = new AppShell();
                    break;
            }
>>>>>>> 5d5264017b774d93c3f9a2e8ae838480ab931b82
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