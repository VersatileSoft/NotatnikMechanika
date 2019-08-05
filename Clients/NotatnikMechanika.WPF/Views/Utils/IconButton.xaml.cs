using MaterialDesignThemes.Wpf;
using System.Windows.Controls;
using System.Windows.Media;

namespace NotatnikMechanika.WPF.Views.Utils
{
    /// <summary>
    /// Interaction logic for IconButton.xaml
    /// </summary>
    public partial class IconButton : Button
    {
        public IconButton()
        {
            InitializeComponent();
        }

        public Brush Color
        {
            get => Icon.Foreground;
            set => Icon.Foreground = value;
        }

        public PackIconKind IconKind
        {
            get => Icon.Kind;
            set => Icon.Kind = value;
        }
    }
}