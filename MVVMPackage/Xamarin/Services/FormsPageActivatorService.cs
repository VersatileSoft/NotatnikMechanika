using MvvmPackage.Core;
using MvvmPackage.Xamarin.Pages;
using MvvmPackage.Xamarin.Services.Interfaces;
using System;
using Xamarin.Forms;

namespace MvvmPackage.Xamarin.Services
{
    public class FormsPageActivatorService : IFormsPageActivatorService
    {
        public Page CreatePageFromPageModel<TPageModel>() where TPageModel : PageModelBase
        {
            return CreatePageFromPageModel(typeof(TPageModel));
        }

        public Page CreatePageFromPageModel(Type pageModelType)
        {
            string pageName = pageModelType.Name.Replace("Model", "");
            return (Page)Activator.CreateInstance(Array.Find(IoC.PlatformProjectAssembly.GetTypes(), t => t.Name == pageName));
        }

        public Page CreatePageFromPageModel<TPageModel>(int parameter) where TPageModel : PageModelBase
        {
            MvContentPage<TPageModel> page = CreatePageFromPageModel(typeof(TPageModel)) as MvContentPage<TPageModel>;
            page.PageModel.Parameter = parameter;
            return page;
        }

        public Page CreatePageFromPageModel<TPageModel, TTargetPage>()
            where TPageModel : PageModelBase
            where TTargetPage : Page
        {
            throw new NotImplementedException();
        }
    }
}
