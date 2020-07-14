using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Commodity;
using NotatnikMechanika.Shared.Models.Order;
using NotatnikMechanika.Shared.Models.Service;
using PropertyChanged;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrderPageModel : PageModelBase
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMvNavigationService _navigationService;
        private readonly IMessageDialogService _messageDialogService;

        public ICommand GoBackCommand { get; set; }
        public ICommand AddServiceCommand { get; set; }
        public ICommand AddCommodityCommand { get; set; }

        public OrderExtendedModel OrderModel { get; set; }
        public List<CommodityModel> Commodities { get; set; }
        public List<ServiceModel> Services { get; set; }


        public OrderPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService, IMessageDialogService messageDialogService)
        {
            OrderModel = new OrderExtendedModel();
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            _messageDialogService = messageDialogService;
            GoBackCommand = new AsyncCommand(() => navigationService.NavigateToAsync<MainPageModel>());
            AddServiceCommand = new AsyncCommand(() => _navigationService.NavigateToAsync<AddServiceToOrderPageModel>(OrderModel.Id));
            AddCommodityCommand = new AsyncCommand(() => _navigationService.NavigateToAsync<AddCommodityToOrderPageModel>(OrderModel.Id));

            // navigationService.AfterClose += NavigationService_AfterClose;
        }

        //private void NavigationService_AfterClose(object sender, MvvmCross.Navigation.EventArguments.IMvxNavigateEventArgs e)
        //{
        //    if (e.ViewModel is AddServiceToOrderViewModel || e.ViewModel is AddCommodityToOrderViewModel)
        //    {
        //        Task.Run(Initialize);
        //    }
        //}

        public override async Task Initialize()
        {
            IsLoading = true;
            string orderPath = new OrderPaths().GetFullPath(OrderPaths.GetExtendedOrder.Replace("{orderId}", Parameter.ToString()));
            Response<OrderExtendedModel> orderResponse = await _httpRequestService.SendGet<OrderExtendedModel>(orderPath);

            if (orderResponse.Successful)
            {
                OrderModel = orderResponse.Content;
            }
            else
            {
                await _messageDialogService.ShowMessageDialog(orderResponse.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania zlecenia");
                return;
            }

            string servicesPath = new ServicePaths().GetFullPath(ServicePaths.GetAllInOrderPath.Replace("{orderId}", OrderModel.Id.ToString()));
            Response<List<ServiceModel>> servicesResponse = await _httpRequestService.SendGet<List<ServiceModel>>(servicesPath);

            if (servicesResponse.Successful)
            {
                Services = servicesResponse.Content;
            }
            else
            {
                await _messageDialogService.ShowMessageDialog(servicesResponse.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania usług");
            }

            string commoditiesPath = new CommodityPaths().GetFullPath(CommodityPaths.GetAllInOrderPath.Replace("{orderId}", OrderModel.Id.ToString()));
            Response<List<CommodityModel>> commoditiesResponse = await _httpRequestService.SendGet<List<CommodityModel>>(commoditiesPath);

            if (commoditiesResponse.Successful)
            {
                Commodities = commoditiesResponse.Content;
            }
            else
            {
                await _messageDialogService.ShowMessageDialog(commoditiesResponse.ErrorMessages.FirstOrDefault(), MessageDialogType.Error, "Błąd ładowania towarów");
            }

            IsLoading = false;
        }
    }
}