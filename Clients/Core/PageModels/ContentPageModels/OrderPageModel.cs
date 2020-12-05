using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MvvmPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Commodity;
using NotatnikMechanika.Shared.Models.Order;
using NotatnikMechanika.Shared.Models.Service;
using PropertyChanged;
using System;
using System.Collections.Generic;
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
        public List<CommodityModel> Commodities { get; set; }
        public List<ServiceModel> Services { get; set; }


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

            navigationService.DialogStateChanged += NavigationService_AfterClose;
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
            if (IsLoading)
            {
                return;
            }

            IsLoading = true;

            OrderModel = await InitHelper<OrderExtendedModel>(OrderPaths.Extended(Parameter));
            if (OrderModel == null)
            {
                return;
            }

            Services = await InitHelper<List<ServiceModel>>(ServicePaths.ByOrder(OrderModel.Id));
            Commodities = await InitHelper<List<CommodityModel>>(CommodityPaths.ByOrder(OrderModel.Id));
            
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