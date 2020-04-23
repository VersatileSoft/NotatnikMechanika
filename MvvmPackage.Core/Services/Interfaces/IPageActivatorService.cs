using System;
using System.Reflection;

namespace MvvmPackage.Core.Services.Interfaces
{
    public interface IPageActivatorService<TPage>
    {
        /// <summary>
        /// Crates new page from given page model type
        /// </summary>
        /// <typeparam name="TPageModel">Type of page model</typeparam>
        /// <returns>Returns new page</returns>
        TPage CreatePageFromPageModel<TPageModel>() where TPageModel : PageModelBase;

        /// <summary>
        /// Crates new page from given page model type
        /// </summary>
        /// <param name="pageModelType">Type of page model</param>
        /// <returns>Returns new page</returns>
        TPage CreatePageFromPageModel(Type pageModelType);

        /// <summary>
        /// Crates new page from given page model and pass parameter to page model
        /// </summary>
        /// <typeparam name="TPageModel">Type of page model</typeparam>
        /// <typeparam name="TParameter">Type of page parameter</typeparam>
        /// <param name="parameter">Parameter to pass in page model</param>
        /// <returns>Returns new page</returns>
        TPage CreatePageFromPageModel<TPageModel, TParameter>(TParameter parameter) where TPageModel : PageModelBase<TParameter>;

        /// <summary>
        /// Crates new page of given type from given page model type
        /// </summary>
        /// <typeparam name="TPageModel">Type of page model</typeparam>
        /// <typeparam name="TPage">Type of page to return</typeparam>
        /// <returns>Returns new page of given type</returns>
        TPage CreatePageFromPageModel<TPageModel, TTargetPage>() where TPageModel : PageModelBase where TTargetPage : TPage;
    }
}
