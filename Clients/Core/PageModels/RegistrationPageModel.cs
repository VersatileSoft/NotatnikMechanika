using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.User;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

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

            Response response = await _httpRequestService.SendPost(RegisterModel, new AccountPaths().GetFullPath(AccountPaths.RegisterPath));

            switch (response.ResponseResult)
            {
                case ResponseResult.Successful:
                    await _messageDialogService.ShowMessageDialog("Konto zostało utworzone. Teraz możesz się zalogować.", MessageDialogType.Success, "Rejestracja");
                    await _navigationService.NavigateToAsync<LoginPageModel>();
                    break;

                case ResponseResult.BadRequest:
                    ErrorMessage = response.ErrorMessages?[0];
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd podczas rejestracji");
                    break;

                case ResponseResult.BadModelState:
                    await _messageDialogService.ShowMessageDialog("Wypełnij dane poprawnie", MessageDialogType.Error);
                    break;
            }

            IsWaiting = false;
        }
    }
}