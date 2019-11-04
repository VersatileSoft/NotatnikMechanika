﻿using MaterialDesignThemes.Wpf;
using System.Windows.Controls;

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