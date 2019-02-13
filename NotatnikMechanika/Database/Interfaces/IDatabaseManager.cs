using NotatnikMechanika.Model.Dao;

namespace NotatnikMechanika.Model.Interfaces
{
    public interface IDatabaseManager
    {
        CarsDao CarsDao { get; }
        CustomersDao CustomersDao { get; }
        ServicesDao ServicesDao { get; }
        GoodsDao GoodsDao { get; }
        OrdersDao OrdersDao { get; }
    }
}