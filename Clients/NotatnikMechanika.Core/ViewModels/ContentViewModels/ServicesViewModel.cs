using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Service;
using PropertyChanged;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels.ContentViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ServicesViewModel : MvxViewModel
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMvxNavigationService _navigationService;

        public IEnumerable<ServiceModel> Services { get; set; }

        public ICommand AddServiceCommand { get; set;  }
        public ICommand ServiceSelectedCommand { get; set;  }


        public ServicesViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService)
        {
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;

            AddServiceCommand = new MvxAsyncCommand(() => _navigationService.Navigate<AddServiceViewModel>());
            ServiceSelectedCommand = new MvxAsyncCommand<int>((id) => _navigationService.Navigate<ServiceViewModel, int>(id));
        }

        public override async Task Initialize()
        {
            Response<List<ServiceModel>> response = await _httpRequestService.SendGet<List<ServiceModel>>(new ServicePaths().GetFullPath(CRUDPaths.GetAllPath), true);

            if(response.StatusCode == HttpStatusCode.OK)
            {
                Services = response.Content;
            }
        }
    }
}
