using System;

namespace MvvmPackage.Core.Services.Interfaces
{
    public interface IPageActivatorService<TPage>
    {
        /// <summary>
        /// Crates new page from given page model type
        /// </summary>
        /// <param name="pageModelType">Type of page model</param>
        /// <returns>Returns new page</returns>
        TPage CreatePageFromPageModel(Type pageModelType, int? parameter = null);

        /// <summary>
        /// Crates new page from given page model and pass parameter to page model
        /// </summary>
        /// <typeparam name="TPageModel">Type of page model</typeparam>
        /// <param name="parameter">Parameter to pass in page model</param>
        /// <returns>Returns new page</returns>
        TPage CreatePageFromPageModel<TPageModel>(int? parameter = null) where TPageModel : PageModelBase;
    }
}
