using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Model;
using NotatnikMechanika.Shared;
using PropertyChanged;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class AddingPageModelBase<TModel> : PageModelBase<int> where TModel : new()
    {
        public TModel Model { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
        public bool IsWaiting { get; set; }

        protected readonly IHttpRequestService _httpRequestService;
        protected readonly IMvNavigationService _navigationService;
        protected readonly IMessageDialogService _messageDialogService;

        public virtual string ErrorMessage { get; set; }
        public abstract string SuccesMessage { get; set; }

        protected AddingPageModelBase(IMvNavigationService navigationService, IHttpRequestService httpRequestService, IMessageDialogService messageDialogService)
        {
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            _messageDialogService = messageDialogService;
            Model = new TModel();
            AddCommand = new AsyncCommand(AddAction);
            GoBackCommand = new AsyncCommand(() => _navigationService.PopAsync());
        }

        private async Task AddAction()
        {
            IsWaiting = true;
            string path = PathsHelper.GetPathsByModel<TModel>().GetFullPath(CRUDPaths.CreatePath);
            Response<ResultBase> respone = await _httpRequestService.SendPost(Model, path);
            IsWaiting = false;
            if (respone.StatusCode == HttpStatusCode.OK)
            {
                await _messageDialogService.ShowMessageDialog(SuccesMessage);
                await _navigationService.NavigateToAsync<MainPageModel>();
            }
            else
            {
                ErrorMessage = respone.ErrorMessages?.FirstOrDefault();
                await _messageDialogService.ShowMessageDialog(ErrorMessage);
            }
        }
    }
}