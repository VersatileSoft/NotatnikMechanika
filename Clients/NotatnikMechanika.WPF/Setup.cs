using MvvmCross;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.Platforms.Wpf.Presenters;
using NotatnikMechanika.Core;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.WPF.Presenters;
using NotatnikMechanika.WPF.Services;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace NotatnikMechanika.WPF
{
    public sealed class Setup : MvxWpfSetup<CoreApp>
    {
        protected override void InitializeFirstChance()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            Mvx.IoCProvider.RegisterSingleton(typeof(ISettingsService), new SettingsService());
            base.InitializeFirstChance();
        }

        protected override void InitializeLastChance()
        {
            // Mvx.IoCProvider.ConstructAndRegisterSingleton<IMvxAppStart, MvxAppStart<MainPageViewModel>>();
            base.InitializeLastChance();
        }

        protected override IMvxWpfViewPresenter CreateViewPresenter(ContentControl root)
        {
            return new MultiRegionWpfViewPresenter(root, Application.Current.Dispatcher);
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