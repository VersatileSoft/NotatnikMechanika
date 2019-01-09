using NotatnikMechanika.Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
