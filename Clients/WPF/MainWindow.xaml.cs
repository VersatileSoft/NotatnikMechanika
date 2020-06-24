using MvvmPackage.Wpf.Pages;

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