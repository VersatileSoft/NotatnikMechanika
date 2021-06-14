using MvvmPackage.Core;
using MvvmPackage.Core.Commands;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Core.Utils;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Commodity;
using NotatnikMechanika.Shared.Models.Order;
using NotatnikMechanika.Shared.Models.Service;
using PropertyChanged;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrderPageModel : PageModelBase
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMessageDialogService _messageDialogService;

        public ICommand GoBackCommand { get; }
        public ICommand? AddServiceCommand { get; }
        public ICommand? AddCommodityCommand { get; }

        public OrderExtendedModel OrderModel { get; set; }
        public TrulyObservableCollection<CommodityModel> Commodities { get; set; }
        public TrulyObservableCollection<ServiceModel> Services { get; set; }


        public OrderPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService, IMessageDialogService messageDialogService)
        {
            _httpRequestService = httpRequestService;
            _messageDialogService = messageDialogService;

            GoBackCommand = new AsyncCommand(navigationService.NavigateToAsync<MainPageModel>);
            OrderModel = new OrderExtendedModel();
            Services = new TrulyObservableCollection<ServiceModel>();
            Commodities = new TrulyObservableCollection<CommodityModel>();
            Services.ItemChanged += Services_ItemChanged;
            Commodities.ItemChanged += Commodities_ItemChanged;
        }

        private async void Commodities_ItemChanged(object sender, PropertyChangedEventArgs e)
        {
            var commodity = (CommodityModel)sender;
            await UpdateItem(OrderPaths.UpdateCommodityStatus(OrderModel.Id, commodity.Id, commodity.Finished));
        }

        private async void Services_ItemChanged(object sender, PropertyChangedEventArgs e)
        {
            var service = (ServiceModel)sender;
            await UpdateItem(OrderPaths.UpdateServiceStatus(OrderModel.Id, service.Id, service.Finished));
        }

        private async Task UpdateItem(string path)
        {
            if (await _httpRequestService.SendUpdate(path, "Błąd aktualizacji zlecenia"))
            {
                _messageDialogService.ShowMessageDialog("Zapisano pomyślnie", MessageDialogType.Success);
            }
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            var order = await _httpRequestService.SendGet<OrderExtendedModel>(OrderPaths.Extended(Parameter ?? 0));

            if (OrderModel == null)
            {
                return;
            }

            OrderModel = order;

            var services = await _httpRequestService.SendGet<List<ServiceModel>>(ServicePaths.ByOrder(OrderModel.Id));

            if (services != null)
            {
                Services.Clear();
                Services.Add(services);
            }

            var commodities = await _httpRequestService.SendGet<List<CommodityModel>>(CommodityPaths.ByOrder(OrderModel.Id));

            if (commodities != null)
            {
                Commodities.Clear();
                Commodities.Add(commodities);
            }

            IsLoading = false;
        }
    }
}