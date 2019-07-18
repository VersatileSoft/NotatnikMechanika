using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.User;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel : MvxViewModel
    {
        public string Login { get; set; } = "Michal";
        public string Password { get; set; } = "123";

        public ICommand LoginCommand { get; set; }

        private readonly IMvxNavigationService _navigationService;
        private readonly IHttpRequestService _httpRequestService;
        private readonly ISettingsService _settingsService;

        public LoginViewModel(IMvxNavigationService navigationService, IHttpRequestService httpRequestService, ISettingsService settingsService)
        {
            _navigationService = navigationService;
            _httpRequestService = httpRequestService;
            _settingsService = settingsService;

            LoginCommand = new MvxAsyncCommand(LoginAction);

        }

        private async Task LoginAction()
        {
            var model = new AuthenticateUserModel
            {
                UserName = Login,
                Password = Password
            };

            Response<TokenModel> response = await _httpRequestService.SendPost<AuthenticateUserModel, TokenModel>(model, AccountPaths.GetFullPath(AccountPaths.LoginPath), false);

            if(response.StatusCode == HttpStatusCode.OK)
            {
                _settingsService.Token = response.Content.Token;
                await _navigationService.Navigate<MainPageViewModel>();
            }
        }
    }
}
