using NotatnikMechanika.Model;
using NotatnikMechanika.Model.Interfaces;
using NotatnikMechanika.Services.Implementation;
using NotatnikMechanika.Services.Interfaces;
using NotatnikMechanika.Views;
using NotatnikMechanika.Views.AddOrder;
using NotatnikMechanika.Views.Navigation;
using Prism.Ioc;
using System.Windows;

namespace NotatnikMechanika
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDatabaseManager, DatabaseManager>();
            containerRegistry.RegisterSingleton<IAddOrderService, AddOrderService>();

            //Navigation
            containerRegistry.RegisterForNavigation<OrdersView>("OrdersView");
            containerRegistry.RegisterForNavigation<MainAppView>("MainAppView");
            containerRegistry.RegisterForNavigation<CustomersView>("CustomersView");
            containerRegistry.RegisterForNavigation<ServicesView>("ServicesView");

            //Adding Order
            containerRegistry.RegisterForNavigation<AddOrderCarInfoView>("AddOrderCarInfoView");
            containerRegistry.RegisterForNavigation<AddOrderCustomerInfoView>("AddOrderCustomerInfoView");
            containerRegistry.RegisterForNavigation<AddOrderGoodsInfoView>("AddOrderGoodsInfoView");
            containerRegistry.RegisterForNavigation<AddOrderInfoView>("AddOrderInfoView");
            containerRegistry.RegisterForNavigation<AddOrderServicesInfoView>("AddOrderServicesInfoView");
        }
    }
}