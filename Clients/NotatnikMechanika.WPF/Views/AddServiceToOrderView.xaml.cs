﻿using MvvmCross.Platforms.Wpf.Views;
using NotatnikMechanika.WPF.Presenters.Attributes;
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

namespace NotatnikMechanika.WPF.Views
{
    /// <summary>
    /// Interaction logic for AddServiceCommodityToOrderView.xaml
    /// </summary>
    [DialogPresentation]
    public partial class AddServiceToOrderView : MvxWpfView
    {
        public AddServiceToOrderView()
        {
            InitializeComponent();
        }
    }
}
