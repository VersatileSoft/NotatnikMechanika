using MvvmPackage.Core;
using MvvmPackage.Wpf.Pages;
using System;
using System.Linq;
using System.Windows.Controls;
using static MvvmPackage.Core.IoC;

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
            Type type = CoreApplicationBase.Assemblies[1].GetTypes().AsEnumerable().FirstOrDefault(t => t.Name == pageName);
            return (UserControl)Activator.CreateInstance(type ?? typeof(UserControl));
        }

        public UserControl CreatePageFromPageModel<TPageModel, TTargetPage>()
            where TPageModel : PageModelBase
            where TTargetPage : UserControl
        {
            throw new NotImplementedException();
        }
    }
}
