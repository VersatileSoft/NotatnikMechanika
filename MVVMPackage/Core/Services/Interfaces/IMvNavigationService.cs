using System;
using System.Threading.Tasks;

namespace MvvmPackage.Core.Services.Interfaces
{
    public interface IMvNavigationService
    {
        event EventHandler<bool> DialogStateChanged;

        /// <summary>
        /// Navigate to page assigned to given page model type
        /// </summary>
        /// <typeparam name="TPageModel">Page model type</typeparam>
        Task NavigateToAsync<TPageModel>() where TPageModel : PageModelBase;
        /// <summary>
        /// Navigate to page assigned to given page model type and pass parameter to page model
        /// </summary>
        /// <typeparam name="TPageModel">Page model type</typeparam>
        /// <param name="parameter">Parameter to pass</param>
        Task NavigateToAsync<TPageModel>(int parameter) where TPageModel : PageModelBase;
        /// <summary>
        /// Pop current presenting page
        /// </summary>
        Task PopAsync();
        Task CloseDialog();
    }
}
