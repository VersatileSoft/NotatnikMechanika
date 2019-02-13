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
    public class AddOrderCustomerInfoViewModel : INavigationAware
    {
        public ICommand AddCustomerCommand { get; set; }
        public ICommand SelectCustomerCommand { get; set; }
        public List<Customer> Customers { get; set; }
        public CustomerDTO Customer { get; set; }

        private IAddOrderService _addOrderService;
        private IRegionManager _regionManager;

        public AddOrderCustomerInfoViewModel(IAddOrderService addOrderService, IRegionManager regionManager)
        {
            _addOrderService = addOrderService;
            _regionManager = regionManager;
            Customer = new CustomerDTO();

            Customers = _addOrderService.GetCustomers();

            AddCustomerCommand = new DelegateCommand(AddCustomer);
            SelectCustomerCommand = new DelegateCommand<object>(SelectCustomer);
        }

        public void AddCustomer()
        {
            _addOrderService.AddCustomer(Customer);
            Customers = _addOrderService.GetCustomers();
        }

        public void SelectCustomer(object id)
        {
            if (id == null) return;

            _addOrderService.SetCustomer((int)id);
            _regionManager.RequestNavigate("ContentRegion", "AddOrderServicesInfoView");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Customers = _addOrderService.GetCustomers();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext) { }
    }
}