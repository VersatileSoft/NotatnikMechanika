using Autofac;
using System;
using System.Reflection;
using Xamarin.Forms;

namespace Xamarin.MVVMPackage
{
    public static class Helpers
    {
        public static Assembly CoreAssembly { get; set; }
        public static Assembly ProjectAssembly { get; set; }

        /// <summary>
        /// Crates new page from given page model type
        /// </summary>
        /// <typeparam name="TPageModel">Type of page model</typeparam>
        /// <returns>Returns new page</returns>
        public static Page CreatePageFromPageModel<TPageModel>() where TPageModel : PageModelBase
        {
            return CreatePageFromPageModel(typeof(TPageModel));
        }

        /// <summary>
        /// Crates new page from given page model type
        /// </summary>
        /// <param name="pageModelType">Type of page model</param>
        /// <returns>Returns new page</returns>
        public static Page CreatePageFromPageModel(Type pageModelType)
        {
            string pageName = pageModelType.Name.Replace("Model", "");
            return (Page)Activator.CreateInstance(Array.Find(ProjectAssembly.GetTypes(), t => t.Name == pageName));
        }

        /// <summary>
        /// Crates new page from given page model and pass parameter to page model
        /// </summary>
        /// <typeparam name="TPageModel">Type of page model</typeparam>
        /// <typeparam name="TParameter">Type of page parameter</typeparam>
        /// <param name="parameter">Parameter to pass in page model</param>
        /// <returns>Returns new page</returns>
        public static Page CreatePageFromPageModel<TPageModel, TParameter>(TParameter parameter) where TPageModel : PageModelBase<TParameter>
        {
            Page page = IoC.Container.ResolveNamed<Page>(typeof(TPageModel).Name.Replace("Model", ""));
            TPageModel pageModel = (TPageModel)IoC.Container.Resolve(typeof(TPageModel));
            pageModel.Parameter = parameter;
            page.BindingContext = pageModel;
            page.Disappearing += (s, e) => pageModel.OnDisappearing();
            page.Appearing += (s, e) => pageModel.OnAppearing();
            return page;
        }

        /// <summary>
        /// Crates new page of given type from given page model type
        /// </summary>
        /// <typeparam name="TPageModel">Type of page model</typeparam>
        /// <typeparam name="TPage">Type of page to return</typeparam>
        /// <returns>Returns new page of given type</returns>
        public static TPage CreatePageFromPageModel<TPageModel, TPage>() where TPageModel : PageModelBase where TPage : Page
        {
            Page page = CreatePageFromPageModel<TPageModel>();
            if (page is TPage p)
            {
                return p;
            }
            else
            {
                throw new Exception(page.GetType().Name + "is not subtype of" + typeof(TPage).Name);
            }
        }
    }
}
