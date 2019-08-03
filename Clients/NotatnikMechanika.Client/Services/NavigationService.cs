using Microsoft.AspNetCore.Components;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NotatnikMechanika.Client.Services
{
    public class NavigationService : IMvxNavigationService
    {
        private readonly IUriHelper _uriHelper;

        public event BeforeNavigateEventHandler BeforeNavigate;
        public event AfterNavigateEventHandler AfterNavigate;
        public event BeforeCloseEventHandler BeforeClose;
        public event AfterCloseEventHandler AfterClose;
        public event BeforeChangePresentationEventHandler BeforeChangePresentation;
        public event AfterChangePresentationEventHandler AfterChangePresentation;

        public NavigationService(IUriHelper uriHelper)
        {
            _uriHelper = uriHelper;
        }

        public async Task<bool> CanNavigate(string path)
        {
            return true;
        }

        public async Task<bool> CanNavigate<TViewModel>() where TViewModel : IMvxViewModel
        {
            return true;
        }

        public async Task<bool> CanNavigate(Type viewModelType)
        {
            return true;
        }

        public async Task<bool> ChangePresentation(MvxPresentationHint hint, CancellationToken cancellationToken = default)
        {
            return true;
        }

        public async Task<bool> Close(IMvxViewModel viewModel, CancellationToken cancellationToken = default)
        {
            return false;
        }

        public async Task<bool> Close<TResult>(IMvxViewModelResult<TResult> viewModel, TResult result, CancellationToken cancellationToken = default)
        {
            return false;
        }

        public Task<bool> Navigate(IMvxViewModel viewModel, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            string vmName = viewModel.GetType().Name;
            _uriHelper.NavigateTo("/" + (vmName.EndsWith("ViewModel")
                ? vmName.Substring(0, vmName.Length - 9)
                : vmName));
            return Task.FromResult(true);
        }

        public Task<bool> Navigate<TParameter>(IMvxViewModel<TParameter> viewModel, TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> Navigate<TResult>(IMvxViewModelResult<TResult> viewModel, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> Navigate<TParameter, TResult>(IMvxViewModel<TParameter, TResult> viewModel, TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Navigate(Type viewModelType, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Navigate<TParameter>(Type viewModelType, TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> Navigate<TResult>(Type viewModelType, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> Navigate<TParameter, TResult>(Type viewModelType, TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Navigate(string path, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Navigate<TParameter>(string path, TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> Navigate<TResult>(string path, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> Navigate<TParameter, TResult>(string path, TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Navigate<TViewModel>(IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default) where TViewModel : IMvxViewModel
        {
            string vmName = typeof(TViewModel).Name;
            _uriHelper.NavigateTo("/" + (vmName.EndsWith("ViewModel")
                ? vmName.Substring(0, vmName.Length - 9)
                : vmName));
            return Task.FromResult(true);
        }

        public Task<bool> Navigate<TViewModel, TParameter>(TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default) where TViewModel : IMvxViewModel<TParameter>
        {
            throw new NotImplementedException();
        }

        public Task<TResult> Navigate<TViewModel, TResult>(IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default) where TViewModel : IMvxViewModelResult<TResult>
        {
            throw new NotImplementedException();
        }

        public Task<TResult> Navigate<TViewModel, TParameter, TResult>(TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default) where TViewModel : IMvxViewModel<TParameter, TResult>
        {
            throw new NotImplementedException();
        }
    }
}
