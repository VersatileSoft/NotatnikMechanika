using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.User;
using PropertyChanged;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginPageModel : PageModelBase
    {
        public LoginModel LoginModel { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsWaiting { get; set; }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        private readonly IAuthService _authService;
        private readonly IMessageDialogService _messageDialogService;

        public LoginPageModel(IAuthService authService, IMvNavigationService navigationService, IMessageDialogService messageDialogService)
        {
            _authService = authService;
            _messageDialogService = messageDialogService;

            LoginModel = new LoginModel();
            LoginCommand = new AsyncCommand(LoginAction);
            RegisterCommand = new AsyncCommand(navigationService.NavigateToAsync<RegistrationPageModel>);
        }

        public async Task LoginAction()
        {
            IsWaiting = true;
            Response<TokenModel> loginResult = await _authService.LoginAsync(LoginModel);
            if (!loginResult.Successful)
            {
                await _messageDialogService.ShowMessageDialog(loginResult.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd podczas logowania");
            }
            IsWaiting = false;
        }
    }
}