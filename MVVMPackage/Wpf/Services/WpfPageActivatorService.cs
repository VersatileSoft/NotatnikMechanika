using MvvmPackage.Core;
using System;
using System.Windows.Controls;

namespace MvvmPackage.Wpf.Services
{
    internal class WpfPageActivatorService : IWpfPageActivatorService
    {

        public UserControl CreatePageFromPageModel<TPageModel>() where TPageModel : PageModelBase
        {
            return CreatePageFromPageModel(typeof(TPageModel));
        }

        public UserControl CreatePageFromPageModel(Type pageModelType)
        {
            string pageName = pageModelType.Name.Replace("Model", "");
            return (UserControl)Activator.CreateInstance(Array.Find(IoC.PlatformProjectAssembly.GetTypes(), t => t.Name == pageName));
        }

        public UserControl CreatePageFromPageModel<TPageModel, TParameter>(TParameter parameter) where TPageModel : PageModelBase<TParameter>
        {
            throw new NotImplementedException();
        }

        public UserControl CreatePageFromPageModel<TPageModel, TTargetPage>()
            where TPageModel : PageModelBase
            where TTargetPage : UserControl
        {
            throw new NotImplementedException();
        }
    }
}
