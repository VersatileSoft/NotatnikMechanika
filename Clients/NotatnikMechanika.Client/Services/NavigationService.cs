using System;
using System.Threading;
using System.Threading.Tasks;

namespace NotatnikMechanika.Client.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IUriHelper _uriHelper;

        public NavigationService(IUriHelper uriHelper)
        {
            _uriHelper = uriHelper;
        }


        public Task<bool> Navigate(IMvxViewModel viewModel, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            string vmName = viewModel.GetType().Name;
            _uriHelper.NavigateTo("/" + (vmName.EndsWith("ViewModel")
                ? vmName.Substring(0, vmName.Length - 9)
                : vmName));
            return Task.FromResult(true);
        }


        public Task<bool> Navigate<TViewModel>(IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default) where TViewModel : IMvxViewModel
        {
            string vmName = typeof(TViewModel).Name;
            _uriHelper.NavigateTo("/" + (vmName.EndsWith("ViewModel")
                ? vmName.Substring(0, vmName.Length - 9)
                : vmName));
            return Task.FromResult(true);
        }
    }
}
