using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels.AddingViewModels
{
    public class AddCommodityToOrderViewModel : MvxViewModel<int>
    {
        private int _orderId;
        private readonly IHttpRequestService _httpRequestService;

        public List<CommodityModel> CommodityModels { get; set; }

        public ICommand CloseCommand { get; set; }

        public AddCommodityToOrderViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService)
        {
            _httpRequestService = httpRequestService;
            CloseCommand = new MvxAsyncCommand(() => navigationService.Close(this));
        }

        public override void Prepare(int orderId)
        {
            _orderId = orderId;
        }

        public override async Task Initialize()
        {
            Response<List<CommodityModel>> response = await _httpRequestService.SendGet<List<CommodityModel>>(new CommodityPaths().GetFullPath(CRUDPaths.GetAllPath), true);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                CommodityModels = response.Content;
            }
        }
    }
}
