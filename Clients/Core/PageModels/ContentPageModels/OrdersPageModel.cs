using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Order;
using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrdersPageModel : PageModelBase
    {
        public ObservableCollection<OrderExtendedModel> Orders { get; set; }
        public ICommand AddOrderCommand { get; }
        public ICommand OrderSelectedCommand { get; set; }
        public ICommand RemoveOrderCommand { get; }
        public ICommand RefreshOrdersCommand { get; set; }

        private readonly IHttpRequestService _httpRequestService;
        private readonly IMessageDialogService _messageDialogService;

        public OrdersPageModel(IMvNavigationService navigationService, IHttpRequestService httpRequestService, IMessageDialogService messageDialogService)
        {
            _httpRequestService = httpRequestService;
            _messageDialogService = messageDialogService;
            Orders = new ObservableCollection<OrderExtendedModel>();
            AddOrderCommand = new AsyncCommand(navigationService.NavigateToAsync<AddOrderPageModel>);
            OrderSelectedCommand = new AsyncCommand<int>(navigationService.NavigateToAsync<OrderPageModel>);
            RemoveOrderCommand = new AsyncCommand<int>(RemoveOrderAction);
            RefreshOrdersCommand = new AsyncCommand(Initialize);
        }

        private async Task RemoveOrderAction(int id)
        {
            if (await _httpRequestService.Delete<OrderModel>(id, "Błąd podczas usuwania zlecenia"))
            {
                Orders.Remove(Orders.Single(o => o.Id == id));
                _messageDialogService.ShowMessageDialog("Pomyślnie usunięto zlecenie", MessageDialogType.Success);
            }
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            var orders = await _httpRequestService.SendGet<List<OrderExtendedModel>>(OrderPaths.Extended(Parameter.HasValue), "Błąd ładowania zleceń");
            if (orders != null)
            {
                Orders.Clear();
                orders.ForEach(i => Orders.Add(i));
            }
            IsLoading = false;
        }
    }
}