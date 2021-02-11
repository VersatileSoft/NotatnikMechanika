using MvvmPackage.Core;
using MvvmPackage.Xamarin.Pages;
using MvvmPackage.Xamarin.Services.Interfaces;
using System;
using Xamarin.Forms;

namespace MvvmPackage.Xamarin.Services
{
    public class FormsPageActivatorService : IFormsPageActivatorService
    {
        public Page CreatePageFromPageModel<TPageModel>(int? parameter) where TPageModel : PageModelBase
        {
            return CreatePageFromPageModel(typeof(TPageModel), parameter);
        }

        public Page CreatePageFromPageModel(Type pageModelType, int? parameter)
        {
            string pageName = pageModelType.Name.Replace("Model", "");
            MvContentPage page = (MvContentPage)Activator.CreateInstance(Array.Find(IoC.PlatformProjectAssembly.GetTypes(), t => t.Name == pageName));
            page.PageModel.Parameter = parameter;
            return page;
        }
    }
}
