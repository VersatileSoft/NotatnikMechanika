using MaterialDesignThemes.Wpf;
using System;
using System.Windows.Controls;

namespace NotatnikMechanika.WPF.Pages.Utils
{
    /// <summary>
    /// Interaction logic for MenuButton.xaml
    /// </summary>
    public partial class MenuButton : Button
    {
        public Type DetailPageModelType { get; set; }

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