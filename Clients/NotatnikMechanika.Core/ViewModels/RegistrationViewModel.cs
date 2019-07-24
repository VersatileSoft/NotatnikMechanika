using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.User;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels
{
    public class RegistrationViewModel : MvxViewModel
    {
        public CreateUserModel CreateUserModel { get; set; }
        public string ConfirmPassword { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public string ErrorMessage { get; set; }


        private readonly IMvxNavigationService _navigationService;
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMessageDialogService _messageDialogService;

        public RegistrationViewModel(IMvxNavigationService navigationService, IHttpRequestService httpRequestService, IMessageDialogService messageDialogService)
        {
            _navigationService = navigationService;
            _httpRequestService = httpRequestService;
            _messageDialogService = messageDialogService;
            CreateUserModel = new CreateUserModel();
            RegisterCommand = new MvxAsyncCommand(RegisterAction);
            LoginCommand = new MvxAsyncCommand(async () => await navigationService.Navigate<LoginViewModel>());
        }

        private async Task RegisterAction()
        {
            if (CreateUserModel.Password != ConfirmPassword)
            {
                ErrorMessage = "Hasła są różne";
                return;
            }

            Response response = await _httpRequestService.SendPost(CreateUserModel, new AccountPaths().GetFullPath(AccountPaths.CreatePath), false);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                await _messageDialogService.ShowMessageDialog("Konto zostało utworzone. Teraz możesz się zalogować.");
                await _navigationService.Navigate<LoginViewModel>();
            }
            else
            {
                ErrorMessage = response.ErrorMessage;
            }
        }
    }
}
