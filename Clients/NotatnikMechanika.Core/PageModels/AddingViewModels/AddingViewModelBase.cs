using PropertyChanged;
using Xamarin.MVVMPackage;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class AddingViewModelBase<TModel> : PageModelBase<int> where TModel : new()
    {
        //public TModel Model { get; set; }
        //public ICommand AddCommand { get; set; }
        //public ICommand GoBackCommand { get; set; }
        //public bool IsWaiting { get; set; }

        //protected readonly IHttpRequestService _httpRequestService;
        //protected readonly IMvxNavigationService _navigationService;
        //protected readonly IMessageDialogService _messageDialogService;

        //public virtual string ErrorMessage { get; set; }
        //public abstract string SuccesMessage { get; set; }

        //public AddingViewModelBase(IHttpRequestService httpRequestService, IMvxNavigationService navigationService, IMessageDialogService messageDialogService)
        //{
        //    _httpRequestService = httpRequestService;
        //    _navigationService = navigationService;
        //    _messageDialogService = messageDialogService;
        //    Model = new TModel();
        //    AddCommand = new MvxAsyncCommand(AddAction);
        //    GoBackCommand = new MvxAsyncCommand(() => _navigationService.Navigate<MainPageViewModel>());
        //}

        //public override void Prepare(int parameter)
        //{
        //}

        //private async Task AddAction()
        //{
        //    IsWaiting = true;
        //    string a = PathsHelper.GetPathsByModel<TModel>().GetFullPath(CRUDPaths.CreatePath);
        //    Response respone = await _httpRequestService.SendPost(Model, a, true);
        //    IsWaiting = false;
        //    if (respone.StatusCode == HttpStatusCode.OK)
        //    {
        //        await _messageDialogService.ShowMessageDialog(SuccesMessage);
        //        await _navigationService.Navigate<MainPageViewModel>();
        //    }
        //    else
        //    {
        //        ErrorMessage = respone.ErrorMessage;
        //        await _messageDialogService.ShowMessageDialog(ErrorMessage);
        //    }
        //}
    }
}