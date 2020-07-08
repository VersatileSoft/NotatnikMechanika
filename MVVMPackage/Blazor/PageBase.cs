using Microsoft.AspNetCore.Components;
using MvvmPackage.Core;
using System.Threading.Tasks;

namespace MVVMPackage.Blazor
{
    public class PageBase<TPageModel> : ComponentBase where TPageModel : PageModelBase
    {
        [Parameter]
        public string Parameter { get; set; }

        [Inject]
        protected TPageModel PageModel { get; set; }

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
    }
}
