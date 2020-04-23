using MvvmPackage.Core;
using MvvmPackage.Xamarin.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
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

        public Page CreatePageFromPageModel<TPageModel, TParameter>(TParameter parameter) where TPageModel : PageModelBase<TParameter>
        {
            throw new NotImplementedException();
        }

        public Page CreatePageFromPageModel<TPageModel, TTargetPage>()
            where TPageModel : PageModelBase
            where TTargetPage : Page
        {
            throw new NotImplementedException();
        }
    }
}
