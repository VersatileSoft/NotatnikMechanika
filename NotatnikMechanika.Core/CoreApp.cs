using MvvmCross.IoC;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.ViewModels;

namespace NotatnikMechanika.Core
{
    public class CoreApp : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainPageViewModel>();
        }
    }
}
