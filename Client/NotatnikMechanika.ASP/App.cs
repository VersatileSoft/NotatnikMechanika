using MvvmCross;
using MvvmCross.Core;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using NotatnikMechanika.Core;
using System;
using System.Threading.Tasks;

namespace NotatnikMechanika.ASP
{
    public class App
    {

        public App()
        {
            RegisterSetup();
            ApplicationInitialized();
        }

        public virtual void ApplicationInitialized()
        {
            SetupSingleton.EnsureSingletonAvailable().EnsureInitialized();
        }

        protected virtual void RegisterSetup()
        {
            this.RegisterSetupType<Setup>();
        }
    }

    public class SetupSingleton : MvxSetupSingleton
    {
        public static SetupSingleton EnsureSingletonAvailable()
        {
            SetupSingleton instance = EnsureSingletonAvailable<SetupSingleton>();
            return instance;
        }
    }

    public class Setup : MvxSetup
    {
        protected override IMvxApplication CreateApp()
        {
            return Mvx.IoCProvider.IoCConstruct<CoreApp>();
        }

        protected override IMvxViewDispatcher CreateViewDispatcher()
        {
            return new ViewDispatcher();
        }

        protected override IMvxViewsContainer CreateViewsContainer()
        {
            return new ViewsContainer();
        }

        protected override IMvxNameMapping CreateViewToViewModelNaming()
        {
            return new MvxPostfixAwareViewToViewModelNameMapping();
        }
    }

    public class ViewsContainer : MvxViewsContainer
    {

    }

    public class ViewDispatcher : IMvxViewDispatcher
    {
        public bool IsOnMainThread => true;

        public Task<bool> ChangePresentation(MvxPresentationHint hint)
        {
            //throw new NotImplementedException();
            return Task.FromResult(true);
        }

        public Task ExecuteOnMainThreadAsync(Action action, bool maskExceptions = true)
        {
            return Task.CompletedTask;
        }

        public Task ExecuteOnMainThreadAsync(Func<Task> action, bool maskExceptions = true)
        {
            return Task.CompletedTask;
        }

        public bool RequestMainThreadAction(Action action, bool maskExceptions = true)
        {
            return true;
        }

        public Task<bool> ShowViewModel(MvxViewModelRequest request)
        {
            return Task.FromResult(true);
        }
    }
}