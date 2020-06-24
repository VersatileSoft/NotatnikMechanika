using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using System.Windows;

namespace MvvmPackage.Wpf
{
    public abstract class MvWpfApplication<TMainPageService> : Application where TMainPageService : IMainPageService
    {
        protected MvWpfApplication()
        {
            IoC.PlatformProjectAssembly = GetType().Assembly;
            IoC.CoreProjectAssembly = typeof(TMainPageService).Assembly;
            IoC.PlatformPackageProjectAssembly = typeof(MvWpfApplication<TMainPageService>).Assembly;
            IoC.RegisterTypes();
        }
    }
}
