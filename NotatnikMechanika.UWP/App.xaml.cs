using MvvmCross.Platforms.Uap.Views;
using NotatnikMechanika.Core;

namespace NotatnikMechanika.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public abstract class UWPApplication : MvxApplication<Setup, CoreApp> { }

    public sealed partial class App : UWPApplication
    {
        public App()
        {
            InitializeComponent();
        }
    }
}
