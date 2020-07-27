using Autofac;
using MvvmPackage.Core;
using MvvmPackage.Wpf.Pages;
using NotatnikMechanika.Core.Interfaces;
using System;

namespace NotatnikMechanika.WPF
{
    public partial class MainWindow : MvMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigationService = MainFrame.NavigationService;
            LoadMainPage();
            MainDialogHost = DialogHost;
        }

        protected override void OnInitialized(EventArgs e)
        {
            var authService = IoC.Container.Resolve<IAuthService>();
            authService.AuthChanged += (s, e) => LoadMainPage();
            base.OnInitialized(e);
        }
    }
}