using System.Windows;
using System.Windows.Controls;

namespace NotatnikMechanika.WPF.Views.Utils
{
    public partial class ButtonIndicator : Button
    {
        public ButtonIndicator()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty IsWaitingProperty = DependencyProperty.Register("IsWaiting", typeof(bool), typeof(ButtonIndicator), new
            PropertyMetadata(false, new PropertyChangedCallback(OnIsWaitingChanged)));

        public bool IsWaiting
        {
            get => (bool)GetValue(IsWaitingProperty);
            set => SetValue(IsWaitingProperty, value);
        }

        public string Text
        {
            get => Label.Content as string;
            set => Label.Content = value;
        }

        private static void OnIsWaitingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ButtonIndicator UserControl1Control = d as ButtonIndicator;
            UserControl1Control.OnIsWaitingChanged(e);
        }

        private void OnIsWaitingChanged(DependencyPropertyChangedEventArgs e)
        {
            bool isWaiting = (bool)e.NewValue;

            Label.Visibility = isWaiting ? Visibility.Collapsed : Visibility.Visible;
            Progress.Visibility = isWaiting ? Visibility.Visible : Visibility.Collapsed;
            IsEnabled = !isWaiting;
        }
    }
}