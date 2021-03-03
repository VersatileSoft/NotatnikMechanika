using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NotatnikMechanika.WPF.Pages.Utils
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

        public static readonly DependencyProperty IconKindProperty = DependencyProperty.Register("IconKind", typeof(PackIconKind), typeof(IconButton), new
            PropertyMetadata(PackIconKind.Read, new PropertyChangedCallback(OnOnIconKindChanged)));

        private static void OnOnIconKindChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            var UserControl1Control = d as IconButton;
            UserControl1Control.OnOnIconKindChanged(e);
        }

        private void OnOnIconKindChanged(DependencyPropertyChangedEventArgs e)
        {
            Icon.Kind = (PackIconKind)e.NewValue;
        }

        public Brush Color
        {
            get => Icon.Foreground;
            set => Icon.Foreground = value;
        }

        public PackIconKind IconKind
        {
            get => (PackIconKind)GetValue(IconKindProperty);
            set => SetValue(IconKindProperty, value);
        }
    }
}