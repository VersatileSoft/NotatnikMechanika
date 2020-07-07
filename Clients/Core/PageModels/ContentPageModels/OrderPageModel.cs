using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Model;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Commodity;
using NotatnikMechanika.Shared.Models.Order;
using NotatnikMechanika.Shared.Models.Service;
using PropertyChanged;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrderPageModel : PageModelBase<OrderExtendedModel>
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMvNavigationService _navigationService;

        public ICommand GoBackCommand { get; set; }
        public ICommand AddServiceCommodityCommand { get; set; }

        public OrderExtendedModel OrderModel { get; set; }
        public List<CommodityModel> Commodities { get; set; }
        public List<ServiceModel> Services { get; set; }


        public OrderPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService)
        {
            OrderModel = new OrderExtendedModel();
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            GoBackCommand = new AsyncCommand(() => navigationService.NavigateToAsync<MainPageModel>());
           // AddServiceCommodityCommand = new AsyncCommand<bool>(AddServiceCommodityAction);

           // navigationService.AfterClose += NavigationService_AfterClose;
        }

        //private void NavigationService_AfterClose(object sender, MvvmCross.Navigation.EventArguments.IMvxNavigateEventArgs e)
        //{
        //    if (e.ViewModel is AddServiceToOrderViewModel || e.ViewModel is AddCommodityToOrderViewModel)
        //    {
        //        Task.Run(Initialize);
        //    }
        //}

        //private async Task AddServiceCommodityAction(bool isService)
        //{
        //    if (isService)
        //    {
        //        await _navigationService.NavigateToAsync<AddServiceToOrderPageModel, int>(OrderModel.Id);
        //    }
        //    else
        //    {
        //        await _navigationService.NavigateToAsync<AddCommodityToOrderPageModel, int>(OrderModel.Id);
        //    }
        //}

        //public override void Prepare(OrderExtendedModel model)
        //{
        //    OrderModel = model;
        //}

        public override async Task Initialize()
        {
            OrderModel = Parameter;

            Response<List<ServiceModel>> servicesResponse = await _httpRequestService.SendGet<List<ServiceModel>>(new ServicePaths().GetFullPath(ServicePaths.GetAllInOrderPath.Replace("{orderId}", OrderModel.Id.ToString())));

            if (servicesResponse.StatusCode == HttpStatusCode.OK)
            {
                Services = servicesResponse.Content;
            }

            Response<List<CommodityModel>> commoditiesResponse = await _httpRequestService.SendGet<List<CommodityModel>>(new CommodityPaths().GetFullPath(CommodityPaths.GetAllInOrderPath.Replace("{orderId}", OrderModel.Id.ToString())));

            if (commoditiesResponse.StatusCode == HttpStatusCode.OK)
            {
                Commodities = commoditiesResponse.Content;
            }
        }
    }
}