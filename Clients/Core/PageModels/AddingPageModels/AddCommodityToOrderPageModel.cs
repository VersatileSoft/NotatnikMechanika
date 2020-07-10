using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    public class AddCommodityToOrderPageModel : PageModelBase
    {
        private int _orderId;
        private readonly IHttpRequestService _httpRequestService;

        public List<CommodityForOrderModel> CommodityModels { get; set; }

        public ICommand CloseCommand { get; set; }
        public ICommand AddRemoveCommodityCommand { get; set; }

        public AddCommodityToOrderPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService)
        {
            _httpRequestService = httpRequestService;
            CloseCommand = new AsyncCommand(() => navigationService.CloseDialog());
            AddRemoveCommodityCommand = new AsyncCommand<CommodityForOrderModel>(AddRemoveCommodityAction);
        }

        private async Task AddRemoveCommodityAction(CommodityForOrderModel commodityModel)
        {
            Response response;
            if (commodityModel.IsInOrder)
            {
                response = await _httpRequestService.SendDelete(new OrderPaths().GetFullPath(OrderPaths.DeleteCommodityFromOrder.Replace("{orderId}", _orderId.ToString()).Replace("{commodityId}", commodityModel.Id.ToString())));
            }
            else
            {
                response = await _httpRequestService.SendPost(new OrderPaths().GetFullPath(OrderPaths.AddCommodityToOrder.Replace("{orderId}", _orderId.ToString()).Replace("{commodityId}", commodityModel.Id.ToString())));
            }

            if (response.Successful)
            {
                await Initialize();
            }
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            _orderId = Parameter;
            Response<List<CommodityForOrderModel>> response = await _httpRequestService.SendGet<List<CommodityForOrderModel>>(new CommodityPaths().GetFullPath(CommodityPaths.GetAllForOrderPath.Replace("{orderId}", _orderId.ToString())));

            if (response.Successful)
            {
                CommodityModels = response.Content;
            }
            IsLoading = false;
        }
    }
}