using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.User;
using PropertyChanged;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel : MvxViewModel
    {
        public AuthenticateUserModel UserModel { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsWaiting { get; set; }

        public IMvxCommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        private readonly IMvxNavigationService _navigationService;
        private readonly IHttpRequestService _httpRequestService;
        private readonly ISettingsService _settingsService;

        public LoginViewModel(IMvxNavigationService navigationService, IHttpRequestService httpRequestService, ISettingsService settingsService)
        {
            _navigationService = navigationService;
            _httpRequestService = httpRequestService;
            _settingsService = settingsService;
            UserModel = new AuthenticateUserModel();

            LoginCommand = new MvxAsyncCommand(LoginAction);
            RegisterCommand = new MvxAsyncCommand(async () => await navigationService.Navigate<RegistrationViewModel>());
        }

        private async Task LoginAction()
        {
            IsWaiting = true;
            Response<TokenModel> response = await _httpRequestService.SendPost<AuthenticateUserModel, TokenModel>(UserModel, new AccountPaths().GetFullPath(AccountPaths.LoginPath), false);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                _settingsService.Token = response.Content.Token;
                await _navigationService.Navigate<MainPageViewModel>();
            }
            else
            {
                ErrorMessage = response.ErrorMessage;
            }
            IsWaiting = false;
        }
    }
}