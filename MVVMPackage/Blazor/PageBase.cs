using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.DependencyInjection;
using MvvmPackage.Core;
using System;
using System.Threading.Tasks;

namespace MVVMPackage.Blazor
{
    public class PageBase<TPageModel> : ComponentBase where TPageModel : PageModelBase
    {
        [Parameter]
        public string Parameter { get; set; }
        public RenderFragment RenderFragment => BuildRenderTree;

        [Inject]
        public TPageModel PageModel { get; private set; }

        protected override async Task OnParametersSetAsync()
        {
            PageModel.PropertyChanged += (s, e) => StateHasChanged();

            if(Parameter == null)
            {
                PageModel.Parameter = null;
            }
            else
            {
                PageModel.Parameter = int.TryParse(Parameter, out var param) ? param : 1;
            }

            await PageModel.Initialize();
            await base.OnParametersSetAsync();
        }

        public async Task DialogInitialize(IServiceProvider services, int parameter = 0)
        {
            PageModel = services.GetService<TPageModel>();
            if (PageModel != null)
            {
                PageModel.Parameter = parameter;
                await PageModel.Initialize();
            }
        }
    }
}
