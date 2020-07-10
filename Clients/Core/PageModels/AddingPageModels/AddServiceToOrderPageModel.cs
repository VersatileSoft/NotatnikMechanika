using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    public class AddServiceToOrderPageModel : PageModelBase
    {
        private int _orderId;
        private readonly IHttpRequestService _httpRequestService;

        public List<ServiceForOrderModel> ServiceModels { get; set; }

        public ICommand CloseCommand { get; set; }
        public ICommand AddRemoveServiceCommand { get; set; }

        public AddServiceToOrderPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService)
        {
            _httpRequestService = httpRequestService;
            CloseCommand = new AsyncCommand(() => navigationService.CloseDialog());
            AddRemoveServiceCommand = new AsyncCommand<ServiceForOrderModel>(AddRemoveServiceAction);
        }

         private async Task AddRemoveServiceAction(ServiceForOrderModel serviceModel)
         {
             IsLoading = true;
             Response response;

             if (serviceModel.IsInOrder)
             {
                 response = await _httpRequestService.SendDelete(new OrderPaths().GetFullPath(OrderPaths.DeleteServiceFromOrder.Replace("{orderId}", _orderId.ToString()).Replace("{serviceId}", serviceModel.Id.ToString())));
             }
             else
             {
                 response = await _httpRequestService.SendPost(new OrderPaths().GetFullPath(OrderPaths.AddServiceToOrder.Replace("{orderId}", _orderId.ToString()).Replace("{serviceId}", serviceModel.Id.ToString())));
             }

             if (response.Successful)
             {
                 await Initialize();
             }
             IsLoading = false;
         }

        public override async Task Initialize()
        {
            IsLoading = true;
            _orderId = Parameter;

            Response<List<ServiceForOrderModel>> response = await _httpRequestService.SendGet<List<ServiceForOrderModel>>(new ServicePaths().GetFullPath(ServicePaths.GetAllForOrderPath.Replace("{orderId}", _orderId.ToString())));

            if (response.Successful)
            {
                ServiceModels = response.Content;
            }
            IsLoading = false;
        }
    }
}