using MaterialDesignThemes.Wpf;
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
