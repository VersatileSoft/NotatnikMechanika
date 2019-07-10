using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using NotatnikMechanika.Core.ViewModels;
using System.Windows;
using System.Windows.Media.Animation;

namespace NotatnikMechanika.WPF.Views
{
   // [MvxContentPresentation()]
   public partial class MainPageView : MvxWpfView
   {
       public MainPageView()
       {
           InitializeComponent();
       }
    }
}
