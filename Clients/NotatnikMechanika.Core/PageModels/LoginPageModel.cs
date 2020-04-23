using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.User;
using PropertyChanged;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.MVVMPackage;
using Xamarin.MVVMPackage.Commands;
using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginPageModel : PageModelBase
    {
        //public AuthenticateUserModel UserModel { get; set; }
        //public string ErrorMessage { get; set; }
        //public bool IsWaiting { get; set; }

        //public ICommand LoginCommand { get; set; }
        //public ICommand RegisterCommand { get; set; }

        //private readonly INavigationService _navigationService;
        //private readonly IHttpRequestService _httpRequestService;
        //private readonly ISettingsService _settingsService;

        //public LoginPageModel(INavigationService navigationService, IHttpRequestService httpRequestService, ISettingsService settingsService)
        //{
        //    _navigationService = navigationService;
        //    _httpRequestService = httpRequestService;
        //    _settingsService = settingsService;
        //    UserModel = new AuthenticateUserModel();

        //    LoginCommand = new AsyncCommand(LoginAction);
        //    RegisterCommand = new AsyncCommand(async () => await navigationService.NavigateToAsync<RegistrationPageModel>());
        //}

        //private async Task LoginAction()
        //{
        //    IsWaiting = true;
        //    Response<TokenModel> response = await _httpRequestService.SendPost<AuthenticateUserModel, TokenModel>(UserModel, new AccountPaths().GetFullPath(AccountPaths.LoginPath), false);
        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        _settingsService.Token = response.Content.Token;
        //        await _navigationService.NavigateToAsync<MainPageModel>();
        //    }
        //    else
        //    {
        //        ErrorMessage = response.ErrorMessage;
        //    }
        //    IsWaiting = false;
        //}
    }
}