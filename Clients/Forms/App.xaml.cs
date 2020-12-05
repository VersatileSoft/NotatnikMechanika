﻿using MvvmPackage.Xamarin;
using NotatnikMechanika.Core;
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
    public partial class App : MvFormsApplication<CoreApplication>
    {
        public App()
        {
            InitializeComponent();
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