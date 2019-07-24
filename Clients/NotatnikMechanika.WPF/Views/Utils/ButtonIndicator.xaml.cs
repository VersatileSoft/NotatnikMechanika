using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotatnikMechanika.WPF.Views.Utils
{
    /// <summary>
    /// Interaction logic for ButtonIndicator.xaml
    /// </summary>
    public partial class ButtonIndicator : Button
    {
        public ButtonIndicator()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty IsWaitingProperty =
   DependencyProperty.Register("IsWaiting", typeof(bool), typeof(ButtonIndicator), new
      PropertyMetadata(false, new PropertyChangedCallback(OnIsWaitingChanged)));

        public bool IsWaiting
        {
            get { return (bool)GetValue(IsWaitingProperty); }
            set { SetValue(IsWaitingProperty, value); }
        }

        private static void OnIsWaitingChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
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
