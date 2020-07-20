using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Order;
using PropertyChanged;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrdersPageModel : PageModelBase
    {
        public IEnumerable<OrderExtendedModel> Orders { get; set; }
        public ICommand AddOrderCommand { get; set; }
        public ICommand OrderSelectedCommand { get; set; }
        public ICommand RemoveOrderCommand { get; set; }

        private readonly IHttpRequestService _httpRequestService;
        private readonly IMvNavigationService _navigationService;
        private readonly IMessageDialogService _messageDialogService;

        public OrdersPageModel(IMvNavigationService navigationService, IHttpRequestService httpRequestService, IMessageDialogService messageDialogService)
        {
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            _messageDialogService = messageDialogService;
            AddOrderCommand = new AsyncCommand(() => _navigationService.NavigateToAsync<AddOrderPageModel>());
            OrderSelectedCommand = new AsyncCommand<int>((id) => _navigationService.NavigateToAsync<OrderPageModel>(id));
            RemoveOrderCommand = new AsyncCommand<int>(RemoveOrderAction);
        }

        private async Task RemoveOrderAction(int id)
        {
            Response response = await _httpRequestService.SendDelete(new OrderPaths().GetFullPath(CRUDPaths.DeletePath.Replace("{id}", id.ToString())));

            switch (response.ResponseResult)
            {
                case ResponseResult.Successful:
                    await _messageDialogService.ShowMessageDialog("Pomyślnie usunięto zlecenie", MessageDialogType.Success);
                    break;

                case ResponseResult.BadRequest:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd podczas usuwania zlecenia");
                    break;
            }

            await Initialize();
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            Response<List<OrderExtendedModel>> response = await _httpRequestService.SendGet<List<OrderExtendedModel>>(new OrderPaths().GetFullPath(OrderPaths.GetExtendedOrders));

            switch (response.ResponseResult)
            {
                case ResponseResult.Successful:
                    Orders = response.Content;
                    break;

                case ResponseResult.BadRequest:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania zleceń");
                    break;
            }

            IsLoading = false;
        }
    }
}