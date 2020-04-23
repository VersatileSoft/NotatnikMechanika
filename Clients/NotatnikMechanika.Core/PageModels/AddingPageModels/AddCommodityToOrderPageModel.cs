using MvvmPackage.Core;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.MVVMPackage;

namespace NotatnikMechanika.Core.PageModels
{
    public class AddCommodityToOrderPageModel : PageModelBase<int>
    {
        //private int _orderId;
        //private readonly IHttpRequestService _httpRequestService;

        //public List<CommodityForOrderModel> CommodityModels { get; set; }

        //public ICommand CloseCommand { get; set; }
        //public ICommand AddRemoveCommodityCommand { get; set; }

        //public AddCommodityToOrderViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService)
        //{
        //    _httpRequestService = httpRequestService;
        //    CloseCommand = new MvxAsyncCommand(() => navigationService.Close(this));
        //    AddRemoveCommodityCommand = new MvxAsyncCommand<CommodityForOrderModel>(AddRemoveCommodityAction);
        //}

        //private async Task AddRemoveCommodityAction(CommodityForOrderModel commodityModel)
        //{
        //    Response response;
        //    if (commodityModel.IsInOrder)
        //    {
        //        response = await _httpRequestService.SendDelete(new OrderPaths().GetFullPath(OrderPaths.DeleteCommodityFromOrder.Replace("{orderId}", _orderId.ToString()).Replace("{commodityId}", commodityModel.Id.ToString())), true);
        //    }
        //    else
        //    {
        //        response = await _httpRequestService.SendPost(new OrderPaths().GetFullPath(OrderPaths.AddCommodityToOrder.Replace("{orderId}", _orderId.ToString()).Replace("{commodityId}", commodityModel.Id.ToString())), true);
        //    }

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        await Initialize();
        //    }
        //}

        //public override void Prepare(int orderId)
        //{
        //    _orderId = orderId;
        //}

        //public override async Task Initialize()
        //{
        //    Response<List<CommodityForOrderModel>> response = await _httpRequestService.SendGet<List<CommodityForOrderModel>>(new CommodityPaths().GetFullPath(CommodityPaths.GetAllForOrderPath.Replace("{orderId}", _orderId.ToString())), true);

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        CommodityModels = response.Content;
        //    }
        //}
    }
}