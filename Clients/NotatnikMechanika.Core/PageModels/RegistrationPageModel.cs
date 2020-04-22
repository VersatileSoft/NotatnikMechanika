using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.User;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.MVVMPackage;
using Xamarin.MVVMPackage.Commands;
using Xamarin.MVVMPackage.Services.Interfaces;

namespace NotatnikMechanika.Core.PageModels
{
    public class RegistrationPageModel : PageModelBase
    {
        public CreateUserModel CreateUserModel { get; set; }
        public string ConfirmPassword { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsWaiting { get; set; }

        private readonly INavigationService _navigationService;
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMessageDialogService _messageDialogService;

        public RegistrationPageModel(INavigationService navigationService, IHttpRequestService httpRequestService, IMessageDialogService messageDialogService)
        {
            _navigationService = navigationService;
            _httpRequestService = httpRequestService;
            _messageDialogService = messageDialogService;
            CreateUserModel = new CreateUserModel();
            RegisterCommand = new AsyncCommand(RegisterAction);
            LoginCommand = new AsyncCommand(async () => await navigationService.NavigateToAsync<LoginPageModel>());
        }

        private async Task RegisterAction()
        {
            IsWaiting = true;
            if (CreateUserModel.Password != ConfirmPassword)
            {
                ErrorMessage = "Hasła są różne";
                return;
            }

            Response response = await _httpRequestService.SendPost(CreateUserModel, new AccountPaths().GetFullPath(AccountPaths.CreatePath), false);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                await _messageDialogService.ShowMessageDialog("Konto zostało utworzone. Teraz możesz się zalogować.");
                await _navigationService.NavigateToAsync<LoginPageModel>();
            }
            else
            {
                ErrorMessage = response.ErrorMessage;
            }
            IsWaiting = false;
        }
    }
}