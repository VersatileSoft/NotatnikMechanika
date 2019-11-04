using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Models;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Core.ViewModels.ContentViewModels;
using NotatnikMechanika.Shared;
using PropertyChanged;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ArchivedOrdersViewModel : MvxViewModel
    {
        public IEnumerable<OrderExtendedModel> ArchivedOrders { get; set; }
        public ICommand ArchivedOrderSelectedCommand { get; set; }
        public bool IsLoading { get; set; }

        private readonly IHttpRequestService _httpRequestService;
        private readonly IMvxNavigationService _navigationService;
        public ArchivedOrdersViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService)
        {
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            ArchivedOrderSelectedCommand = new MvxAsyncCommand<OrderExtendedModel>((order) => _navigationService.Navigate<OrderViewModel, OrderExtendedModel>(order));
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            Response<List<OrderExtendedModel>> response = await _httpRequestService.SendGet<List<OrderExtendedModel>>(new OrderPaths().GetFullPath(OrderPaths.GetArchivedExtendedOrders), true);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                ArchivedOrders = response.Content;
            }
            IsLoading = false;
        }
    }
}