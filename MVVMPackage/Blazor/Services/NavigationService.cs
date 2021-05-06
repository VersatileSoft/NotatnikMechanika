using Microsoft.AspNetCore.Components;
using MvvmPackage.Core;
using MvvmPackage.Core.Attributes;
using MvvmPackage.Core.Services.Interfaces;
using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;

namespace MvvmPackage.Blazor.Services
{
    [SingleInstance]
    public class NavigationService : IMvNavigationService
    {
        private readonly NavigationManager _navigationManager;
        private readonly IServiceProvider _services;

        public Action<bool, RenderFragment> DialogChanged;
        private bool _dialogIsOpen;

        public event EventHandler<bool> DialogStateChanged;

        public bool DialogIsOpen
        {
            get => _dialogIsOpen;
            set
            {
                if (value == _dialogIsOpen)
                {
                    return;
                }

                _dialogIsOpen = value;
                DialogStateChanged?.Invoke(this, value);
            }
        }

        public RenderFragment DialogContent { get; set; } = _ => { };

        public NavigationService(NavigationManager navigationManager, IServiceProvider services)
        {
            _navigationManager = navigationManager;
            _services = services;
        }

        public async Task NavigateToAsync<TPageModel>() where TPageModel : PageModelBase
        {
            if (IsDialog<TPageModel>(out var pageType))
            {
                await OpenDialog<TPageModel>(pageType);
            }
            else
            {
                _navigationManager.NavigateTo(PageName<TPageModel>().ToLower(CultureInfo.CurrentCulture));
            }
        }

        public async Task NavigateToAsync<TPageModel>(int parameter) where TPageModel : PageModelBase
        {
            if (IsDialog<TPageModel>(out var dialogType))
            {
                await OpenDialog<TPageModel>(dialogType, parameter);
            }
            else
            {
                _navigationManager.NavigateTo($"{PageName<TPageModel>().ToLower(CultureInfo.CurrentCulture)}/{parameter}");
            }
        }

        private async Task OpenDialog<TPageModel>(Type dialogType, int parameter = 0) where TPageModel : PageModelBase
        {
            if (Activator.CreateInstance(dialogType) is not PageBase<TPageModel> dialog)
            {
                return;
            }

            await dialog.DialogInitialize(_services, parameter);
            dialog.PageModel.PropertyChanged += (s, e) => DialogStateChanged?.Invoke(this, DialogIsOpen);
            DialogContent = dialog.RenderFragment;
            DialogIsOpen = true;
        }

        private static bool IsDialog<TPageModel>(out Type pageType)
        {
            var types = IoC.PlatformProjectAssembly.GetTypes();
            string pageName = PageName<TPageModel>();
            pageType = Array.Find(types, t => t.Name == pageName);
            return pageType?.GetCustomAttribute<DisplayDialogAttribute>() != null;
        }

        private static string PageName<TPageModel>()
        {
            string vmName = typeof(TPageModel).Name;
            return vmName.EndsWith("PageModel", StringComparison.CurrentCulture)
                ? vmName.Replace("PageModel", "")
                : vmName;
        }

        public Task PopAsync()
        {
            throw new NotImplementedException();
        }

        public Task CloseDialog()
        {
            DialogIsOpen = false;
            return Task.CompletedTask;
        }
    }
}
