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
    /// Interaction logic for MenuButton.xaml
    /// </summary>
    public partial class MenuButton : Button
    {
        public MenuButton()
        {
            InitializeComponent();
        }

        public string Text
        {
            get => TextLabel.Content as string;
            set => TextLabel.Content = value;
        }

        public PackIconKind IconKind
        {
            get => Icon.Kind;
            set => Icon.Kind = value;
        }
    }
}
