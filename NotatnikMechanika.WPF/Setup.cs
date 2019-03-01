using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core;
using NotatnikMechanika.Core.ViewModels;
using System.Collections.Generic;
using System.Reflection;

namespace NotatnikMechanika.WPF
{
    public sealed class Setup : MvxWpfSetup<CoreApp>
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
