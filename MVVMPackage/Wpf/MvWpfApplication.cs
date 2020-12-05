using MvvmPackage.Core;
using System.Windows;

namespace MvvmPackage.Wpf
{
    public abstract class MvWpfApplication<CoreApp> : Application where CoreApp : CoreApplicationBase , new()
    {
        protected MvWpfApplication()
        {
            var a = GetType().Assembly;
            CoreApplicationBase.CreateApp<CoreApp>(new[]
                 {
                    typeof(MvWpfApplication<CoreApp>).Assembly,
                    a
                });           
        }      
    }
}
