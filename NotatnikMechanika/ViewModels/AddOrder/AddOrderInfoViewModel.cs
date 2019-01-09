using NotatnikMechanika.Database.Models;
using NotatnikMechanika.Model.Interfaces;
using NotatnikMechanika.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.ViewModels.AddOrder
{
    [AddINotifyPropertyChangedInterface]
    public class AddOrderInfoViewModel : INavigationAware
    {

        public ICommand AddOrderCommand { get; set; }
        public OrderDTO Order { get; set; }

        private IAddOrderService _addOrderService;
        private IRegionManager _regionManager;
        

        public AddOrderInfoViewModel(IAddOrderService addOrderService, IRegionManager regionManager)
        {
            _addOrderService = addOrderService;
            _regionManager = regionManager;
            Order = new OrderDTO();

            AddOrderCommand = new DelegateCommand(AddOrder);
        }
        
        public void AddOrder()
        {
            _addOrderService.SaveOrder(Order);
            _regionManager.RequestNavigate("ContentRegion", "MainAppView");
        }
        
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Order.StartOrderDate = DateTime.Now.Date;
            Order.FinishOrderDate = DateTime.Now.Date;
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
