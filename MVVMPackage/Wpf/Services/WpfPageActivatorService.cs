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
        public UserControl CreatePageFromPageModel<TPageModel>(int? parameter) where TPageModel : PageModelBase
        {
            return CreatePageFromPageModel(typeof(TPageModel), parameter);
        }

        public UserControl CreatePageFromPageModel(Type pageModelType, int? parameter)
        {
            string pageName = pageModelType.Name.Replace("Model", "");
            var type = PlatformProjectAssembly.GetTypes().AsEnumerable().FirstOrDefault(t => t.Name == pageName);
            var page = (MvWpfPage)Activator.CreateInstance(type ?? typeof(UserControl));
            page.PageModel.Parameter = parameter;
            return page;
        }
    }
}
