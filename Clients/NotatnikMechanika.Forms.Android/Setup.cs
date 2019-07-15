using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;
using NotatnikMechanika.Core;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Forms.Android.Services;

namespace NotatnikMechanika.Forms.Android
{
    public sealed class Setup : MvxFormsAndroidSetup<CoreApp, App>
    {
        protected override void InitializeFirstChance()
        {
            Mvx.IoCProvider.RegisterSingleton(typeof(ISettingsService), new SettingsService());
            base.InitializeFirstChance();
        }
    }
}