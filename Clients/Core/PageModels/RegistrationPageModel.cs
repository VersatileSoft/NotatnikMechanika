using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Model;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.User;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.PageModels
{
    public class RegistrationPageModel : PageModelBase
    {
        public RegisterModel RegisterModel { get; set; }
        public string ConfirmPassword { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsWaiting { get; set; }

        private readonly IMvNavigationService _navigationService;
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMessageDialogService _messageDialogService;

        public RegistrationPageModel(IMvNavigationService navigationService, IHttpRequestService httpRequestService, IMessageDialogService messageDialogService)
        {
            _navigationService = navigationService;
            _httpRequestService = httpRequestService;
            _messageDialogService = messageDialogService;
            RegisterModel = new RegisterModel();
            RegisterCommand = new AsyncCommand(RegisterAction);
            LoginCommand = new AsyncCommand(async () => await navigationService.NavigateToAsync<LoginPageModel>());
        }

        public async Task RegisterAction()
        {
            IsWaiting = true;

            Response<RegisterResult> response;
            if (RegisterModel.Password != ConfirmPassword)
            {
                response = Response<RegisterResult>.GetBadModelState(new List<string> { "Hasła są różne" });
            }
            else
            {
                response = await _httpRequestService.SendPost<RegisterModel, RegisterResult>(RegisterModel, new AccountPaths().GetFullPath(AccountPaths.RegisterPath));
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                await _messageDialogService.ShowMessageDialog("Konto zostało utworzone. Teraz możesz się zalogować.");
                await _navigationService.NavigateToAsync<LoginPageModel>();
            }
            else
            {
                ErrorMessage = response.ErrorMessages?[0];
            }
            IsWaiting = false;
        }
    }
}