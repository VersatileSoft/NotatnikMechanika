using MvvmPackage.Core;
using MvvmPackage.Wpf.Pages;
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

        public UserControl CreatePageFromPageModel<TPageModel>(int parameter) where TPageModel : PageModelBase
        {
            MvWpfPage<TPageModel> page = (MvWpfPage<TPageModel>)CreatePageFromPageModel<TPageModel>();
            if (page == null)
            {
                throw new NullReferenceException("Could not cast page");
            }
            page.PageModel.Parameter = parameter;
            return page;
        }

        public UserControl CreatePageFromPageModel(Type pageModelType)
        {
            string pageName = pageModelType.Name.Replace("Model", "");
            return (UserControl)Activator.CreateInstance(Array.Find(IoC.PlatformProjectAssembly.GetTypes(), t => t.Name == pageName));
        }

        public UserControl CreatePageFromPageModel<TPageModel, TTargetPage>()
            where TPageModel : PageModelBase
            where TTargetPage : UserControl
        {
            throw new NotImplementedException();
        }
    }
}
