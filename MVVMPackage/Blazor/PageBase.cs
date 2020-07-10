using Microsoft.AspNetCore.Components;
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
        public TPageModel PageModel { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            PageModel.PropertyChanged += (s, e) => StateHasChanged();

            if (int.TryParse(Parameter, out int param))
            {
                PageModel.Parameter = param;
            }
            else
            {
                PageModel.Parameter = 0;
            }
            await PageModel.Initialize();
            await base.OnParametersSetAsync();
        }

        public async Task DialogInitialize(IServiceProvider services, int parameter = 0)
        {
            PageModel = services.GetService<TPageModel>();
            PageModel.Parameter = parameter;
            await PageModel.Initialize();
        }
    }
}
