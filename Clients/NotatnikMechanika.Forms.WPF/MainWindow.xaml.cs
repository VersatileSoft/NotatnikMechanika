using Xamarin.Forms.Platform.WPF;

namespace NotatnikMechanika.Forms.WPF
{
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();

            Xamarin.Forms.Forms.Init();
            LoadApplication(new Forms.App());
        }
    }
}