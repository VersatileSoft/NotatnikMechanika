using NotatnikMechanika.Database.Models;
using NotatnikMechanika.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using PropertyChanged;
using System.Collections.Generic;
using System.Windows.Input;

namespace NotatnikMechanika.ViewModels.AddOrder
{
    [AddINotifyPropertyChangedInterface]
    public class AddOrderServicesInfoViewModel : INavigationAware
    {
        public ICommand AddServiceCommand { get; set; }
        public ICommand NextPageCommand { get; set; }
        public ServiceDTO Service { get; set; }

        public List<ServiceDTO> Services { get; set; }

        private IAddOrderService _addOrderService;
        private IRegionManager _regionManager;


        public AddOrderServicesInfoViewModel(IAddOrderService addOrderService, IRegionManager regionManager)
        {
            _addOrderService = addOrderService;
            _regionManager = regionManager;
            Service = new ServiceDTO();
            Services = _addOrderService.GetServices(Services);

            AddServiceCommand = new DelegateCommand(AddService);
            NextPageCommand = new DelegateCommand(NextPage);
        }

        public void AddService()
        {
            _addOrderService.AddService(Service);

            Services = _addOrderService.GetServices(Services);
        }

        public void NextPage()
        {
            _regionManager.RequestNavigate("ContentRegion", "AddOrderGoodsInfoView");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Services = _addOrderService.GetServices(Services);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            _addOrderService.AddServices(Services);
        }
    }
}