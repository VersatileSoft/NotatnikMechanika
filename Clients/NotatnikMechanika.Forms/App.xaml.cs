using NotatnikMechanika.Forms.Views;
using Xamarin.Forms;

namespace NotatnikMechanika.Forms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            switch (Device.RuntimePlatform)
            {
                case Device.WPF:
                    MainPage = new DashboardView();
                    break;
                default:
                    MainPage = new AppShell();
                    break;
            }
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