using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.MVVMPackage;
using MvvmPackage.Core;

namespace NotatnikMechanika.Core.PageModels
{
    public class AddServiceToOrderPageModel : PageModelBase<int>
    {
        //private int _orderId;
        //private readonly IHttpRequestService _httpRequestService;

        //public List<ServiceForOrderModel> ServiceModels { get; set; }

        //public ICommand CloseCommand { get; set; }
        //public ICommand AddRemoveServiceCommand { get; set; }

        //public AddServiceToOrderViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService)
        //{
        //    _httpRequestService = httpRequestService;
        //    CloseCommand = new MvxAsyncCommand(() => navigationService.Close(this));
        //    AddRemoveServiceCommand = new MvxAsyncCommand<ServiceForOrderModel>(AddRemoveServiceAction);
        //}

        //public override void Prepare(int orderId)
        //{
        //    _orderId = orderId;
        //}

        //private async Task AddRemoveServiceAction(ServiceForOrderModel serviceModel)
        //{
        //    Response response;

        //    if (serviceModel.IsInOrder)
        //    {
        //        response = await _httpRequestService.SendDelete(new OrderPaths().GetFullPath(OrderPaths.DeleteServiceFromOrder.Replace("{orderId}", _orderId.ToString()).Replace("{serviceId}", serviceModel.Id.ToString())), true);
        //    }
        //    else
        //    {
        //        response = await _httpRequestService.SendPost(new OrderPaths().GetFullPath(OrderPaths.AddServiceToOrder.Replace("{orderId}", _orderId.ToString()).Replace("{serviceId}", serviceModel.Id.ToString())), true);
        //    }

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        await Initialize();
        //    }
        //}

        //public override async Task Initialize()
        //{
        //    Response<List<ServiceForOrderModel>> response = await _httpRequestService.SendGet<List<ServiceForOrderModel>>(new ServicePaths().GetFullPath(ServicePaths.GetAllForOrderPath.Replace("{orderId}", _orderId.ToString())), true);

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        ServiceModels = response.Content;
        //    }
        //}
    }
}