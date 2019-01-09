using NotatnikMechanika.Model.Interfaces;
using Prism.Commands;
using Prism.Regions;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.ViewModels.Navigation
{
    [AddINotifyPropertyChangedInterface]
    public class CustomersViewModel
    {
        public ICommand AddCustomerCommand { get; set; }
        public ICommand DetailsCustomerCommand { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nip { get; set; }
        public string PhoneNumber { get; set; }

        public List<Customer> Customers { get; set; }

        private IDatabaseManager _databaseManager;
        private IRegionManager _regionManager;

        public CustomersViewModel(IDatabaseManager databaseManager, IRegionManager regionManager)
        {
            _databaseManager = databaseManager;
            _regionManager = regionManager;
            Customers = _databaseManager.CustomersDao.GetCustomers();

            AddCustomerCommand = new DelegateCommand(AddCustomer);
            DetailsCustomerCommand = new DelegateCommand<object>(CustomerDetails);
        }

        public void AddCustomer()
        {
            _databaseManager.CustomersDao.AddCustomer(
                new Customer
                {
                    Address = Address,
                    CompanyName = CompanyName,
                    FirstName = FirstName,
                    LastName = LastName,
                    Nip = Nip,
                    PhoneNumber = PhoneNumber
                });

            Address = "";
            CompanyName = "";
            FirstName = "";
            LastName = "";
            Nip = "";
            PhoneNumber = "";

            Customers = _databaseManager.CustomersDao.GetCustomers();
        }

        public void CustomerDetails(object id)
        {

            //(int)id;

            //_regionManager.RequestNavigate("ContentRegion", "AddOrderServicesInfoView");
            //TODO Navigate to Customer Details and stats
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Customers = _databaseManager.CustomersDao.GetCustomers();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
