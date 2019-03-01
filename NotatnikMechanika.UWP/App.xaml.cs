using MvvmCross.Platforms.Uap.Views;
using NotatnikMechanika.Core;

namespace NotatnikMechanika.UWP
{
    public abstract class UWPApplication : MvxApplication<Setup, CoreApp> { }

    public sealed partial class App : UWPApplication
    {
        public App()
        {
            InitializeComponent();
        }
    }
}
