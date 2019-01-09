using NotatnikMechanika.Database.Models;
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
    public class ServicesViewModel
    {
        public ICommand AddServiceCommand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public List<Service> Services { get; set; }

        private IDatabaseManager _databaseManager;
        private IRegionManager _regionManager;

        public ServicesViewModel(IDatabaseManager databaseManager, IRegionManager regionManager)
        {
            _databaseManager = databaseManager;
            _regionManager = regionManager;

            Services = _databaseManager.ServicesDao.GetServices();

            AddServiceCommand = new DelegateCommand(AddService);
        }
        
        public void AddService()
        {
            _databaseManager.ServicesDao.AddService(
                new Service
                {
                    Name = Name,
                    Description = Description,
                    Price = Price
                });

            Name = "";
            Description = "";
            Price = 0;

            Services = _databaseManager.ServicesDao.GetServices();
        }
        
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Services = _databaseManager.ServicesDao.GetServices();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext){ }
    }
}
