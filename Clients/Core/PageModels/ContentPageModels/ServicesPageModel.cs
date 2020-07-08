using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Model;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models;
using NotatnikMechanika.Shared.Models.Service;
using PropertyChanged;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class ServicesPageModel : PageModelBase
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMvNavigationService _navigationService;
        public IEnumerable<ServiceModel> Services { get; set; }
        public ICommand AddServiceCommand { get; set; }
        public ICommand ServiceSelectedCommand { get; set; }
        public ICommand RemoveServiceCommand { get; set; }

        public ServicesPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService)
        {
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;

            AddServiceCommand = new AsyncCommand(() => _navigationService.NavigateToAsync<AddServicePageModel>());
            ServiceSelectedCommand = new AsyncCommand<int>((id) => _navigationService.NavigateToAsync<ServicePageModel>(id));
            RemoveServiceCommand = new AsyncCommand<int>(RemoveServiceAction);
        }
        private async Task RemoveServiceAction(int id)
        {
            await _httpRequestService.SendDelete(new ServicePaths().GetFullPath(id.ToString()));
            await Initialize();
        }

        public override async Task Initialize()
        {
            IsLoading = true;
            Response<List<ServiceModel>> response = await _httpRequestService.SendGet<List<ServiceModel>>(new ServicePaths().GetFullPath(CRUDPaths.GetAllPath));

            if (response.Successful)
            {
                Services = response.Content;
            }
            IsLoading = false;
        }
    }
}