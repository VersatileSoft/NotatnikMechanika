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
        private readonly IAuthService _authService;

        public OrdersPageModel(IMvNavigationService navigationService, IHttpRequestService httpRequestService, IMessageDialogService messageDialogService, IAuthService authService)
        {
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            _messageDialogService = messageDialogService;
            _authService = authService;
            Orders = new List<OrderExtendedModel>();
            AddOrderCommand = new AsyncCommand(() => _navigationService.NavigateToAsync<AddOrderPageModel>());
            OrderSelectedCommand = new AsyncCommand<int>((id) => _navigationService.NavigateToAsync<OrderPageModel>(id));
            RemoveOrderCommand = new AsyncCommand<int>(RemoveOrderAction);
        }

        private async Task RemoveOrderAction(int id)
        {
            Response response = await _httpRequestService.SendDelete(new OrderPaths().GetFullPath(CRUDPaths.DeletePath.Replace("{id}", id.ToString())));

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    await _messageDialogService.ShowMessageDialog("Pomyślnie usunięto zlecenie", MessageDialogType.Success);
                    break;

                case ResponseType.Failure:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd podczas usuwania zlecenia");
                    break;
            }

            await Initialize();
        }

        public override async Task Initialize()
        {

            if (Orders.Any()) return;

            IsLoading = true;
            Response<List<OrderExtendedModel>> response = await _httpRequestService.SendGet<List<OrderExtendedModel>>(new OrderPaths().GetFullPath(OrderPaths.GetExtendedOrders));

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    Orders = response.Content;
                    break;

                case ResponseType.Failure:
                    await _messageDialogService.ShowMessageDialog(response.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania zleceń");
                    break;

                case ResponseType.Unauthorized:
                    await _authService.LogoutAsync();
                    break;
            }

            IsLoading = false;
        }
    }
}