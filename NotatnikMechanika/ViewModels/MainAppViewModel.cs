using NotatnikMechanika.Model.Interfaces;
using NotatnikMechanika.Views.Navigation;
using Prism.Commands;
using Prism.Regions;
using PropertyChanged;
using System.Windows.Input;

namespace NotatnikMechanika.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainAppViewModel : INavigationAware
    {
        public string Title { get; set; }

        public ICommand NavigationCommand { get; set; }
        public ICommand AddOrderCommand { get; set; }

        private IDatabaseManager _databaseMenager;
        private IRegionManager _regionManager;

        public MainAppViewModel(IDatabaseManager databaseMenager, IRegionManager regionManager)
        {

            _databaseMenager = databaseMenager;
            _regionManager = regionManager;

            NavigationCommand = new DelegateCommand<string>(Navigation);
            AddOrderCommand = new DelegateCommand(AddOrder);

            _regionManager.RegisterViewWithRegion("DetailPage", typeof(OrdersView));

        }

        private void AddOrder()
        {
            _regionManager.RequestNavigate("ContentRegion", "AddOrderCarInfoView");
        }

        private void Navigation(string path)
        {
            _regionManager.RequestNavigate("DetailPage", path);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _regionManager.RequestNavigate("DetailPage", "OrdersView");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext) { }
    }
}