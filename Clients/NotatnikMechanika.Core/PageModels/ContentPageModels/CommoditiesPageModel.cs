using MvvmPackage.Core;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Commodity;
using PropertyChanged;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.MVVMPackage;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class CommoditiesPageModel : PageModelBase
    {
        //private readonly IHttpRequestService _httpRequestService;
        //private readonly IMvxNavigationService _navigationService;
        //public bool IsLoading { get; set; }
        //public IEnumerable<CommodityModel> Commodities { get; set; }

        //public ICommand AddCommodityCommand { get; set; }
        //public ICommand CommoditySelectedCommand { get; set; }


        //public CommoditiesViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService)
        //{
        //    _httpRequestService = httpRequestService;
        //    _navigationService = navigationService;

        //    AddCommodityCommand = new MvxAsyncCommand(() => _navigationService.Navigate<AddCommodityViewModel>());
        //    CommoditySelectedCommand = new MvxAsyncCommand<int>((id) => _navigationService.Navigate<CommodityViewModel, int>(id));
        //}

        //public override async Task Initialize()
        //{
        //    IsLoading = true;
        //    Response<List<CommodityModel>> response = await _httpRequestService.SendGet<List<CommodityModel>>(new CommodityPaths().GetFullPath(CRUDPaths.GetAllPath), true);

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        Commodities = response.Content;
        //    }
        //    IsLoading = false;
        //}
    }
}