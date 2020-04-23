using MvvmPackage.Wpf.Pages;
using System;

namespace NotatnikMechanika.WPF
{
    public partial class MainWindow : MvMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            LoadMainPage();
        }
    }
}