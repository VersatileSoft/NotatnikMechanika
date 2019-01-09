using NotatnikMechanika.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Services.Interfaces
{
    public interface IAddOrderService
    {
        OrderDTO Order { get; set; }

        //CarInfo
        List<Car> GetCars();
        void AddCar(CarDTO carDTO);
        void SetCar(int id);

        //CustomerInfo
        List<Customer> GetCustomers();
        void AddCustomer(CustomerDTO customerDTO);
        void SetCustomer(int id);

        //ServicesInfo
        List<ServiceDTO> GetServices(List<ServiceDTO> services);
        void AddService(ServiceDTO serviceDTO);
        void AddServices(List<ServiceDTO> servicesDTO);

        //GoodsInfo
        void AddGoods(List<GoodDTO> goodsDTO);
        List<GoodDTO> GetGoods(List<GoodDTO> goodsDTO);
        void AddGood(GoodDTO goodDTO);

        //OrderInfo
        void SaveOrder(OrderDTO orderDTO);
    }
}
