using Microsoft.AspNetCore.Components;
using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MVVMPackage.Blazor.Services
{
    public class NavigationService : IMvNavigationService
    {
        private readonly NavigationManager _navigationManager;

        public NavigationService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public Task NavigateToAsync<TPageModel>() where TPageModel : PageModelBase
        {
            _navigationManager.NavigateTo(GetPageName<TPageModel>());
            return Task.CompletedTask;
        }

        public Task NavigateToAsync<TPageModel>(int parameter) where TPageModel : PageModelBase
        {
            _navigationManager.NavigateTo($"{GetPageName<TPageModel>()}/{parameter}");
            return Task.CompletedTask;
        }

        private string GetPageName<TPageModel>()
        {
            string vmName = typeof(TPageModel).Name;
            return "/" + (vmName.EndsWith("PageModel")
                ? vmName.Replace("PageModel", "")
                : vmName).ToLower();
        }

        public Task PopAsync()
        {
            throw new NotImplementedException();
        }
    }
}
