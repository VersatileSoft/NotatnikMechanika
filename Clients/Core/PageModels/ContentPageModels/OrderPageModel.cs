using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Core.Utils;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Commodity;
using NotatnikMechanika.Shared.Models.Order;
using NotatnikMechanika.Shared.Models.Service;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrderPageModel : PageModelBase, IDisposable
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMvNavigationService _navigationService;
        private readonly IMessageDialogService _messageDialogService;

        public ICommand GoBackCommand { get; }
        public ICommand AddServiceCommand { get; }
        public ICommand AddCommodityCommand { get; }
        public ICommand RefreshOrderCommand { get; set; }

        public OrderExtendedModel OrderModel { get; set; }
        public TrulyObservableCollection<CommodityModel> Commodities { get; set; }
        public TrulyObservableCollection<ServiceModel> Services { get; set; }


        public OrderPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService, IMessageDialogService messageDialogService)
        {
            OrderModel = new OrderExtendedModel();
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            _messageDialogService = messageDialogService;
            RefreshOrderCommand = new AsyncCommand(Initialize);
            GoBackCommand = new AsyncCommand(navigationService.NavigateToAsync<MainPageModel>);
            AddServiceCommand = new AsyncCommand(() => _navigationService.NavigateToAsync<AddServiceToOrderPageModel>(OrderModel.Id));
            AddCommodityCommand = new AsyncCommand(() => _navigationService.NavigateToAsync<AddCommodityToOrderPageModel>(OrderModel.Id));
            Commodities = new TrulyObservableCollection<CommodityModel>();
            Services = new TrulyObservableCollection<ServiceModel>();

            Services.ItemChanged += Services_ItemChanged;
            Commodities.ItemChanged += Commodities_ItemChanged;
            navigationService.DialogStateChanged += NavigationService_AfterClose;
        }

        private async void Commodities_ItemChanged(object sender, PropertyChangedEventArgs e)
        {
            var commodity = (CommodityModel)sender;
            Response response = await _httpRequestService.SendUpdate(OrderPaths.UpdateCommodityStatus(OrderModel.Id, commodity.Id, commodity.Finished));
            await NotifyItemChangedResult(response);
        }

        private async void Services_ItemChanged(object sender, PropertyChangedEventArgs e)
        {
            var service = (ServiceModel)sender;
            Response response = await _httpRequestService.SendUpdate(OrderPaths.UpdateServiceStatus(OrderModel.Id, service.Id, service.Finished));
            await NotifyItemChangedResult(response);
        }

        private Task NotifyItemChangedResult(Response response)
        {
            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    return _messageDialogService.ShowMessageDialog(response?.ErrorMessages?.FirstOrDefault(), MessageDialogType.Success, "Zapisano pomyślnie");
                case ResponseType.Failure:
                    return _messageDialogService.ShowMessageDialog(response?.ErrorMessages?.FirstOrDefault(), MessageDialogType.Error, "Błąd aktualizacji zlecenia");
                default: return Task.CompletedTask;
            }
        }

        private void NavigationService_AfterClose(object sender, bool isOpen)
        {
            if (!isOpen)
            {
                Task.Run(Initialize);
            }
        }

        public override async Task Initialize()
        {
            if (IsLoading || Parameter == null)
            {
                return;
            }

            IsLoading = true;

            OrderModel = await InitHelper<OrderExtendedModel>(OrderPaths.Extended(Parameter ?? 0));
            if (OrderModel == null)
            {
                return;
            }

            Services.Clear();
            Commodities.Clear();
            List<ServiceModel> services = await InitHelper<List<ServiceModel>>(ServicePaths.ByOrder(OrderModel.Id));
            List<CommodityModel> commodities = await InitHelper<List<CommodityModel>>(CommodityPaths.ByOrder(OrderModel.Id));
            Services.Add(services);
            Commodities.Add(commodities);   
            IsLoading = false;
        }

        public void Dispose()
        {
            _navigationService.DialogStateChanged -= NavigationService_AfterClose;
        }
        
        private async Task<TResponseContent> InitHelper<TResponseContent>(string path) where TResponseContent : class, new()
        {
            Response<TResponseContent> response = await _httpRequestService.SendGet<TResponseContent>(path);

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    return response.Content;

                case ResponseType.Failure:
                    await _messageDialogService.ShowMessageDialog(response?.ErrorMessages?.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania zlecenia");
                    break;
                case ResponseType.Unauthorized:
                    break;
                case ResponseType.BadModelState:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return null;
        }
    }
}