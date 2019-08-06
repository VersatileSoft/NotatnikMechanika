using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Core.ViewModels.ContentViewModels;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels.AddingViewModels
{
    public class AddServiceToOrderViewModel : MvxViewModel<int>
    {
        private int _orderId;
        private readonly IHttpRequestService _httpRequestService;

        public List<ServiceModel> ServiceModels { get; set; }

        public ICommand CloseCommand { get; set; }

        public AddServiceToOrderViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService)
        {
            _httpRequestService = httpRequestService;
            CloseCommand = new MvxAsyncCommand(() => navigationService.Close(this));
        }

        public override void Prepare(int orderId)
        {
            _orderId = orderId;
        }

        public async override Task Initialize()
        {
            Response<List<ServiceModel>> response = await _httpRequestService.SendGet<List<ServiceModel>>(new ServicePaths().GetFullPath(CRUDPaths.GetAllPath), true);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                ServiceModels = response.Content;
            }
        }
    }
}
