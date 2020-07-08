using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Model;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models;
using NotatnikMechanika.Shared.Models.Commodity;
using PropertyChanged;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class CommoditiesPageModel : PageModelBase
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMvNavigationService _navigationService;
        public IEnumerable<CommodityModel> Commodities { get; set; }
        public ICommand AddCommodityCommand { get; set; }
        public ICommand CommoditySelectedCommand { get; set; }
        public ICommand RemoveCommodityCommand { get; set; }

        public CommoditiesPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService)
        {
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;

            AddCommodityCommand = new AsyncCommand(() => _navigationService.NavigateToAsync<AddCommodityPageModel>());
            CommoditySelectedCommand = new AsyncCommand<int>((id) => _navigationService.NavigateToAsync<CommodityPageModel>(id));
            RemoveCommodityCommand = new AsyncCommand<int>(RemoveCommodityAction);
        }

        private async Task RemoveCommodityAction(int id)
        {
            await _httpRequestService.SendDelete(new CommodityPaths().GetFullPath(id.ToString()));
            await Initialize();
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            Response<List<CommodityModel>> response = await _httpRequestService.SendGet<List<CommodityModel>>(new CommodityPaths().GetFullPath(CRUDPaths.GetAllPath));

            if (response.Successful)
            {
                Commodities = response.Content;
            }
            IsLoading = false;
        }
    }
}