using Microsoft.AspNetCore.Components;
using MvvmPackage.Core;
using System.Threading.Tasks;

namespace MVVMPackage.Blazor
{
    public class PageBase<TPageModel> : ComponentBase where TPageModel : PageModelBase
    {
        [Inject]
        protected TPageModel PageModel { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await PageModel.Initialize();
            await base.OnParametersSetAsync();
        }
    }

    public class PageBaseInt<TPageModel> : PageBase<TPageModel> where TPageModel : PageModelBase<int>
    {
        [Parameter]
        public string Parameter { get; set; }

        protected override Task OnParametersSetAsync()
        {
            if (int.TryParse(Parameter, out int param))
            {
                PageModel.Parameter = param;
            }
            else
            {
                PageModel.Parameter = 0;
            }

            return base.OnParametersSetAsync();
        }
    }

    public class PageBaseString<TPageModel> : PageBase<TPageModel> where TPageModel : PageModelBase<string>
    {
        [Parameter]
        public string Parameter { get; set; }

        protected override void OnParametersSet()
        {
            PageModel.Parameter = Parameter;
            base.OnParametersSet();
        }
    }
}
