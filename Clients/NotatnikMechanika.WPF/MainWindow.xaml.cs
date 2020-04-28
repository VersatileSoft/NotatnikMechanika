using MvvmPackage.Wpf.Pages;
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
        }
    }
}