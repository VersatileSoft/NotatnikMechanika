using Microsoft.AspNetCore.Components;

namespace NotatnikMechanika.Client.Utils
{
    public class Redirect : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Path { get; set; }

        protected override void OnParametersSet()
        {
            NavigationManager.NavigateTo(Path);
        }
    }
}
