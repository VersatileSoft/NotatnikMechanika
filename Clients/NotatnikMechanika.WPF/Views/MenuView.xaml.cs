﻿using MvvmCross.Platforms.Wpf.Views;
using NotatnikMechanika.WPF.Presenters.Attributes;

namespace NotatnikMechanika.WPF.Views
{
    [MasterDetailPage(Position = MasterDetailPageAttribute.MasterDetailPosition.Master)]
    public partial class MenuView : MvxWpfView
    {
        public MenuView()
        {
            InitializeComponent();
        }
    }
}