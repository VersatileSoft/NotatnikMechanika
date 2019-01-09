using NotatnikMechanika;
using NotatnikMechanika.Database.Models;
using NotatnikMechanika.Model.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NotatnikMechanika.ViewModels.Navigation
{
    [AddINotifyPropertyChangedInterface]
    public class OrdersViewModel : INavigationAware
    {

        public string Title { get; set; } 
        public List<OrderPresenter> Orders { get; set; }

        private IDatabaseManager _databaseMenager;

        public OrdersViewModel(IDatabaseManager databaseMenager)
        {
            _databaseMenager = databaseMenager;
            Orders = _databaseMenager.OrdersDao.GetOrders();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Orders = _databaseMenager.OrdersDao.GetOrders();
            //TODO Check why this isn't working(method is not called)
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
