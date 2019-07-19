using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels
{
    public class RegistrationViewModel : MvxViewModel
    {
        public CreateUserModel CreateUserModel { get; set; }
        public ICommand RegisterCommand { get; set; }

        private IMvxNavigationService _navigationService;
        private IHttpRequestService _httpRequestService;
        private IMessageDialogService _messageDialogService;

        public RegistrationViewModel(IMvxNavigationService navigationService, IHttpRequestService httpRequestService, IMessageDialogService messageDialogService)
        {
            _navigationService = navigationService;
            _httpRequestService = httpRequestService;
            _messageDialogService = messageDialogService;
            RegisterCommand = new MvxAsyncCommand(RegisterAction);
        }

        private async Task RegisterAction()
        {
            Response response = await _httpRequestService.SendPost(CreateUserModel, AccountPaths.GetFullPath(AccountPaths.CreatePath), false);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                await _messageDialogService.ShowMessageDialog("Konto zostało utworzone. Zaloguj się.");
                await _navigationService.Navigate<LoginViewModel>();
            }
            else
            {
                await _messageDialogService.ShowMessageDialog("Błąd podczas tworzenia konta" + response.ErrorMessage);
            }
        }
    }
}
