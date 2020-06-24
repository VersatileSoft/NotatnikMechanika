using MvvmPackage.Core;
using PropertyChanged;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class ServicesPageModel : PageModelBase
    {
        //private readonly IHttpRequestService _httpRequestService;
        //private readonly IMvxNavigationService _navigationService;
        //public bool IsLoading { get; set; }
        //public IEnumerable<ServiceModel> Services { get; set; }

        //public ICommand AddServiceCommand { get; set; }
        //public ICommand ServiceSelectedCommand { get; set; }


        //public ServicesViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService)
        //{
        //    _httpRequestService = httpRequestService;
        //    _navigationService = navigationService;

        //    AddServiceCommand = new MvxAsyncCommand(() => _navigationService.Navigate<AddServiceViewModel>());
        //    ServiceSelectedCommand = new MvxAsyncCommand<int>((id) => _navigationService.Navigate<ServiceViewModel, int>(id));
        //}

        //public override async Task Initialize()
        //{
        //    IsLoading = true;
        //    Response<List<ServiceModel>> response = await _httpRequestService.SendGet<List<ServiceModel>>(new ServicePaths().GetFullPath(CRUDPaths.GetAllPath), true);

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        Services = response.Content;
        //    }
        //    IsLoading = false;
        //}
    }
}