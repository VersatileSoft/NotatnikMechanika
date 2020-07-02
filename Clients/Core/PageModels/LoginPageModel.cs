using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.User;
using PropertyChanged;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public LoginPageModel(IAuthService authService, IMvNavigationService navigationService)
        {
            _authService = authService;

            LoginModel = new LoginModel();
            LoginCommand = new AsyncCommand(LoginAction);
            RegisterCommand = new AsyncCommand(navigationService.NavigateToAsync<RegistrationPageModel>);
        }

        public async Task LoginAction()
        {
            IsWaiting = true;
            LoginResult loginResult = await _authService.LoginAsync(LoginModel);
            if (!loginResult.Successful)
            {
                ErrorMessage = loginResult.Errors?.First();
            }
            IsWaiting = false;
        }
    }
}