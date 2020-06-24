using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared.Models.User;
using PropertyChanged;
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

        private readonly IMvNavigationService _navigationService;
        private readonly IHttpRequestService _httpRequestService;
        private readonly ISettingsService _settingsService;

        public LoginPageModel(IMvNavigationService navigationService, /*IHttpRequestService httpRequestService,*/ ISettingsService settingsService)
        {
            _navigationService = navigationService;
            // _httpRequestService = httpRequestService;
            _settingsService = settingsService;
            LoginModel = new LoginModel();

            LoginCommand = new AsyncCommand(LoginAction);
            RegisterCommand = new AsyncCommand(async () => await navigationService.NavigateToAsync<RegistrationPageModel>());
        }

        public async Task LoginAction()
        {
            _settingsService.Token = Task.FromResult("dfrewf"); //response.Content.Token;
            await _navigationService.ReloadMainPage<MainPageService>();


            //IsWaiting = true;
            //Response<TokenModel> response = await _httpRequestService.SendPost<AuthenticateUserModel, TokenModel>(UserModel, new AccountPaths().GetFullPath(AccountPaths.LoginPath), false);
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    _settingsService.Token = response.Content.Token;
            //    await _navigationService.NavigateToAsync<MainPageModel>();
            //}
            //else
            //{
            //    ErrorMessage = response.ErrorMessage;
            //}
            //IsWaiting = false;
        }
    }
}