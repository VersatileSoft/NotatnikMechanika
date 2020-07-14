using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    public class AddServiceToOrderPageModel : PageModelBase
    {
        private int _orderId;
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMessageDialogService _messageDialogService;

        public List<ServiceForOrderModel> ServiceModels { get; set; }

        public ICommand CloseCommand { get; set; }
        public ICommand AddRemoveServiceCommand { get; set; }

        public AddServiceToOrderPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService, IMessageDialogService messageDialogService)
        {
            _httpRequestService = httpRequestService;
            _messageDialogService = messageDialogService;
            CloseCommand = new AsyncCommand(() => navigationService.CloseDialog());
            AddRemoveServiceCommand = new AsyncCommand<ServiceForOrderModel>(AddRemoveServiceAction);
        }

        private async Task AddRemoveServiceAction(ServiceForOrderModel serviceModel)
        {
            IsLoading = true;
            Response response;

            if (serviceModel.IsInOrder)
            {
                string path = new OrderPaths().GetFullPath(OrderPaths.DeleteServiceFromOrder.Replace("{orderId}", _orderId.ToString()).Replace("{serviceId}", serviceModel.Id.ToString()));
                response = await _httpRequestService.SendDelete(path);
            }
            else
            {
                string path = new OrderPaths().GetFullPath(OrderPaths.AddServiceToOrder.Replace("{orderId}", _orderId.ToString()).Replace("{serviceId}", serviceModel.Id.ToString()));
                response = await _httpRequestService.SendPost(path);
            }

            if (response.Successful)
            {
                await _messageDialogService.ShowMessageDialog($"Pomyślnie {(serviceModel.IsInOrder ? "usunięto" : "dodano")} usługę", MessageDialogType.Success);
                await Initialize();
            }
            else
            {
                await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Coś poszło nie tak");
            }
            IsLoading = false;
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            _orderId = Parameter;

            string path = new ServicePaths().GetFullPath(ServicePaths.GetAllForOrderPath.Replace("{orderId}", _orderId.ToString()));
            Response<List<ServiceForOrderModel>> response = await _httpRequestService.SendGet<List<ServiceForOrderModel>>(path);

            if (response.Successful)
            {
                ServiceModels = response.Content;
            }
            else
            {
                await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania usług");
            }
            IsLoading = false;
        }
    }
}