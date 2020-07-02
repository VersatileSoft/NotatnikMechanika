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
            string vmName = typeof(TPageModel).Name;
            _navigationManager.NavigateTo("/" + (vmName.EndsWith("PageModel")
                ? vmName.Replace("PageModel", "")
                : vmName).ToLower());
            return Task.FromResult(true);
        }

        public Task NavigateToAsync<TPageModel, TParameter>(TParameter parameter) where TPageModel : PageModelBase<TParameter>
        {
            throw new NotImplementedException();
        }

        public Task PopAsync()
        {
            throw new NotImplementedException();
        }

        public Task ReloadMainPage<TMainPageService>() where TMainPageService : IMainPageService
        {
            //_navigationManager.

            return null;
        }
    }
}
