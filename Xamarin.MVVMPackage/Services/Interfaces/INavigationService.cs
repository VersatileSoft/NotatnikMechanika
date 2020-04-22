using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.MVVMPackage.Services.Interfaces
{
    public interface INavigationService
    {
        /// <summary>
        /// Navigate to page assigned to given page model type
        /// </summary>
        /// <typeparam name="TPageModel">Page model type</typeparam>
        Task NavigateToAsync<TPageModel>() where TPageModel : PageModelBase;
        /// <summary>
        /// Navigate to page assigned to given page model type and pass parameter to page model
        /// </summary>
        /// <typeparam name="TPageModel">Page model type</typeparam>
        /// <typeparam name="TParameter">Parameter type</typeparam>
        /// <param name="parameter">Parameter to pass</param>
        Task NavigateToAsync<TPageModel, TParameter>(TParameter parameter) where TPageModel : PageModelBase<TParameter>;
        /// <summary>
        /// Pop current presenting page
        /// </summary>
        Task PopAsync();
        Task ReloadMainPage();
    }
}
