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
    public class AddOrderCarInfoViewModel : INavigationAware
    {
        public ICommand AddCarCommand { get; set; }
        public ICommand SelectCarCommand { get; set; }
        public CarDTO Car { get; set; }
        public List<Car> Cars { get; set; }

        private IAddOrderService _addOrderService;
        private IRegionManager _regionManager;

        public AddOrderCarInfoViewModel(IAddOrderService addOrderService, IRegionManager regionManager)
        {
            _addOrderService = addOrderService;
            _regionManager = regionManager;
            Car = new CarDTO();

            Cars = _addOrderService.GetCars();
            AddCarCommand = new DelegateCommand(AddCar);
            SelectCarCommand = new DelegateCommand<object>(SelectCar);
        }

        public void AddCar()
        {
            _addOrderService.AddCar(Car);
            Cars = _addOrderService.GetCars();
        }

        public void SelectCar(object id)
        {
            _addOrderService.SetCar((int)id);
            _regionManager.RequestNavigate("ContentRegion", "AddOrderCustomerInfoView");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Cars = _addOrderService.GetCars();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext) { }
    }
}