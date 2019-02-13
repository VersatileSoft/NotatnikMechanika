using NotatnikMechanika.Model.Dao;
using NotatnikMechanika.Model.Interfaces;

namespace NotatnikMechanika.Model
{
    public class DatabaseManager : IDatabaseManager
    {
        public CarsDao CarsDao
        {
            get
            {
                return new CarsDao();
            }
        }

        public CustomersDao CustomersDao
        {
            get
            {
                return new CustomersDao();
            }
        }

        public ServicesDao ServicesDao
        {
            get
            {
                return new ServicesDao();
            }
        }

        public GoodsDao GoodsDao
        {
            get
            {
                return new GoodsDao();
            }
        }

        public OrdersDao OrdersDao
        {
            get
            {
                return new OrdersDao();
            }
        }
    }
}