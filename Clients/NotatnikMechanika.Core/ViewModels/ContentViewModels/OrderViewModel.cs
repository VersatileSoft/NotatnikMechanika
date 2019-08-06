using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Models;
using NotatnikMechanika.Core.ViewModels.AddingViewModels;
using NotatnikMechanika.Shared.Models.Commodity;
using NotatnikMechanika.Shared.Models.Service;
using PropertyChanged;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels.ContentViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrderViewModel : MvxViewModel<OrderExtendedModel>
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMvxNavigationService _navigationService;

        public ICommand GoBackCommand { get; set; }
        public ICommand AddServiceCommodityCommand { get; set; }

        public OrderExtendedModel OrderModel { get; set; }


        public OrderViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService)
        {
            OrderModel = new OrderExtendedModel();
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            GoBackCommand = new MvxAsyncCommand(() => navigationService.Navigate<MainPageViewModel>());
            AddServiceCommodityCommand = new MvxAsyncCommand<bool>(AddServiceCommodityAction);
        }

        private async Task AddServiceCommodityAction(bool isService)
        {
            if (isService)
                await _navigationService.Navigate<AddServiceToOrderViewModel, int>(OrderModel.Id);
            else
                await _navigationService.Navigate<AddCommodityToOrderViewModel, int>(OrderModel.Id);
        }

        public override void Prepare(OrderExtendedModel model)
        {
            OrderModel = model;
        }
    }
}
