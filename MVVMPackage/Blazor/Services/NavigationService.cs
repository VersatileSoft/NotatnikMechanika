using Microsoft.AspNetCore.Components;
using MvvmPackage.Core;
using MvvmPackage.Core.Attributes;
using MvvmPackage.Core.Services.Interfaces;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace MVVMPackage.Blazor.Services
{
    [SingleInstance]
    public class NavigationService : IMvNavigationService
    {
        private readonly NavigationManager _navigationManager;
        private readonly IServiceProvider _services;

        public Action<bool, RenderFragment> DialogChanged;

        public NavigationService(NavigationManager navigationManager, IServiceProvider services)
        {
            _navigationManager = navigationManager;
            _services = services;
        }

        public async Task NavigateToAsync<TPageModel>() where TPageModel : PageModelBase
        {
            if (IsDialog<TPageModel>(out Type pageType))
            {
                await OpenDialog<TPageModel>(pageType);
            }
            else
            {
                _navigationManager.NavigateTo(GetPageName<TPageModel>().ToLower());
            }
        }

        public async Task NavigateToAsync<TPageModel>(int parameter) where TPageModel : PageModelBase
        {
            if (IsDialog<TPageModel>(out Type dialogType))
            {
                await OpenDialog<TPageModel>(dialogType, parameter);
            }
            else
            {
                _navigationManager.NavigateTo($"{GetPageName<TPageModel>().ToLower()}/{parameter}");
            }
        }

        private async Task OpenDialog<TPageModel>(Type dialogType, int parameter = 0) where TPageModel : PageModelBase
        {
            PageBase<TPageModel> dialog = Activator.CreateInstance(dialogType) as PageBase<TPageModel>;
            await dialog.DialogInitialize(_services, parameter);
            DialogChanged?.Invoke(true, dialog.RenderFragment);
        }

        private bool IsDialog<TPageModel>(out Type pageType)
        {
            Type[] types = IoC.PlatformProjectAssembly.GetTypes();
            string pageName = GetPageName<TPageModel>();
            pageType = Array.Find(types, t => t.Name == pageName);
            return pageType?.GetCustomAttribute<DisplayDialogAttribute>() != null;
        }

        private string GetPageName<TPageModel>()
        {
            string vmName = typeof(TPageModel).Name;
            return vmName.EndsWith("PageModel")
                ? vmName.Replace("PageModel", "")
                : vmName;
        }

        public Task PopAsync()
        {
            throw new NotImplementedException();
        }

        public Task CloseDialog()
        {
            DialogChanged?.Invoke(false, _ => { });
            return Task.CompletedTask;
        }
    }
}
