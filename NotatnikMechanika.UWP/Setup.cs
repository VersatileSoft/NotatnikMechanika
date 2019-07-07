using MvvmCross.Platforms.Uap.Core;
using NotatnikMechanika.Core;

namespace NotatnikMechanika.UWP
{
    public sealed class Setup : MvxWindowsSetup<CoreApp>
    {
        protected override void InitializeFirstChance()
        {
            //   Mvx.IoCProvider.RegisterSingleton(typeof(ISettingsService), new SettingsService());
            base.InitializeFirstChance();
        }

        protected override void InitializeLastChance()
        {
            // Mvx.IoCProvider.ConstructAndRegisterSingleton<IMvxAppStart, MvxAppStart<MainPageViewModel>>();
            base.InitializeLastChance();
        }

        //public override IEnumerable<Assembly> GetViewModelAssemblies()
        //{
        //    List<Assembly> list = new List<Assembly>();
        //    list.AddRange(base.GetViewModelAssemblies());
        //    list.Add(typeof(MainPageViewModel).Assembly);

        //    return list;
        //}
    }
}