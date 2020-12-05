using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace MvvmPackage.Core
{
    public abstract class CoreApplicationBase
    {
        public Type MainPageModelType { get; set; }
        public static List<Assembly> Assemblies { get; set; }
        public static CoreApplicationBase Instance { get; private set; }

        protected CoreApplicationBase()
        {
            IoC.RegisterTypes(RegisterTypes);                
        }

        public static void CreateApp<CoreApp>(Assembly[] assemblies) 
            where CoreApp : CoreApplicationBase, new()
        {
            Assemblies = new List<Assembly>(assemblies)
            {
                typeof(CoreApp).Assembly
            };

            Instance = new CoreApp();
        }

        protected virtual void RegisterTypes(ContainerBuilder containerBuilder) { }

        public virtual Task OnStart()
        {
            return Task.CompletedTask;
        }

        protected void SetMainPageModel<TpageModel>() where TpageModel : PageModelBase
        {
            MainPageModelType = typeof(TpageModel);                  
        }
    }
}
