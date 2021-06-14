using MvvmPackage.Core;
using MvvmPackage.Core.Commands;
using MvvmPackage.Core.Services.Interfaces;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.User;
using PropertyChanged;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginPageModel : PageModelBase
    {
        public LoginModel LoginModel { get; set; }
        public string? ErrorMessage { get; set; }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        private readonly IAuthService _authService;

        public LoginPageModel(IAuthService authService, IMvNavigationService navigationService)
        {
            _authService = authService;

            LoginModel = new LoginModel();
            LoginCommand = new AsyncCommand(LoginAction);
            RegisterCommand = new AsyncCommand(navigationService.NavigateToAsync<RegistrationPageModel>);

            IsLoading = false;
        }

        public async Task LoginAction()
        {
            IsLoading = true;

            //TODO [Blazor-Toast] Check why exception is throwing when bad credentials, temporary try catch
            try
            {
                await _authService.LoginAsync(LoginModel);
            }
            catch (Exception) { }

            IsLoading = false;
        }
    }
}