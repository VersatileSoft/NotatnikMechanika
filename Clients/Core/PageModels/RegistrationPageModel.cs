using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.User;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.PageModels
{
    public class RegistrationPageModel : PageModelBase
    {
        public RegisterModel RegisterModel { get; }
        public string ConfirmPassword { get; set; }
        public ICommand RegisterCommand { get; }
        public ICommand LoginCommand { get; }

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
            LoginCommand = new AsyncCommand(navigationService.NavigateToAsync<LoginPageModel>);
            IsLoading = false;
        }

        public async Task RegisterAction()
        {
            IsLoading = true;

            if(await _httpRequestService.SendPost(RegisterModel, AccountPaths.Register(), "Błąd podczas rejestracji"))
            {
                _messageDialogService.ShowMessageDialog("Konto zostało utworzone. Teraz możesz się zalogować.", MessageDialogType.Success, "Rejestracja");
                await _navigationService.NavigateToAsync<LoginPageModel>();
            }

            IsLoading = false;
        }
    }
}