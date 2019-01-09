using NotatnikMechanika.Database.Models;
using NotatnikMechanika.Model.Interfaces;
using NotatnikMechanika.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Services.Implementation
{
    public class AddOrderService : IAddOrderService
    {
        public OrderDTO Order { get; set; }

        private IDatabaseManager _databaseManager;

        public AddOrderService(IDatabaseManager databaseManager)
        {
            Order = new OrderDTO();
            _databaseManager = databaseManager;
        }

        public void AddCar(CarDTO carDTO)
        {
            Car car = new Car
            {
                Brand = carDTO.Brand,
                Model = carDTO.Model,
                Course = carDTO.Course,
                Engine = carDTO.Engine,
                Power = carDTO.Power,
                ProductionYear = carDTO.ProductionYear,
                RegistrationNumber = carDTO.RegistrationNumber

            };

            _databaseManager.CarsDao.AddCar(car);

            carDTO.Brand = "";
            carDTO.Model = "";
            carDTO.RegistrationNumber = "";
            carDTO.Engine = "";
            carDTO.Power = "";
            carDTO.Course = "";
            carDTO.ProductionYear = "";
        }

        public List<Car> GetCars()
        {
            return _databaseManager.CarsDao.GetCars();
        }

        public void SetCar(int id)
        {
            Order.CarId = id;
        }

        public List<Customer> GetCustomers()
        {
            return _databaseManager.CustomersDao.GetCustomers();
        }

        public void AddCustomer(CustomerDTO customerDTO)
        {
            Customer customer = new Customer
            {
                Address = customerDTO.Address,
                CompanyName = customerDTO.CompanyName,
                FirstName = customerDTO.FirstName,
                LastName = customerDTO.LastName,
                Nip = customerDTO.Nip,
                PhoneNumber = customerDTO.PhoneNumber,

            };

            _databaseManager.CustomersDao.AddCustomer(customer);

            customer.Address = "";
            customer.CompanyName = "";
            customer.FirstName = "";
            customer.LastName = "";
            customer.Nip = "";
            customer.PhoneNumber = "";
        }

        public void SetCustomer(int id)
        {
            Order.CustomerId = id;
        }

        public List<ServiceDTO> GetServices(List<ServiceDTO> services)
        {
            List<ServiceDTO> serviceDTO = new List<ServiceDTO>();

            _databaseManager.ServicesDao.GetServices().ForEach((service) =>
            {
                bool selected = false;
                if (services != null && services.Count() > service.Id)
                    selected = services[service.Id].Selected;

                serviceDTO.Add(new ServiceDTO
                {
                    Name = service.Name,
                    Description = service.Description,
                    Price = service.Price,
                    Selected = selected,
                    Id = service.Id
                });
            });

            return serviceDTO;
        }

        public void AddService(ServiceDTO serviceDTO)
        {
            Service service = new Service
            {
                Description = serviceDTO.Description,
                Name = serviceDTO.Name,
                Price = serviceDTO.Price,              
            };

            _databaseManager.ServicesDao.AddService(service);

            serviceDTO.Name = "";
            serviceDTO.Description = "";
            serviceDTO.Price = 0;
        }

        public void AddServices(List<ServiceDTO> servicesDTO)
        {
            List<int> servicesIds = new List<int>();
            
            servicesDTO.ForEach((service) =>
            {
                if (service.Selected)
                    servicesIds.Add(service.Id);
            });

            Order.ServicesIds = servicesIds;
        }

        public void AddGoods(List<GoodDTO> goodsDTO)
        {
            List<int> goodsIds = new List<int>();

            goodsDTO.ForEach((good) =>
            {
                if (good.Selected)
                    goodsIds.Add(good.Id);
            });

            Order.GoodsIds = goodsIds;
        }

        public List<GoodDTO> GetGoods(List<GoodDTO> goodsDTO)
        {
            List<GoodDTO> GoodDTO = new List<GoodDTO>();

            _databaseManager.GoodsDao.GetGoods().ForEach((good) =>
            {
                bool selected = false;
                if (goodsDTO != null && goodsDTO.Count() > good.Id)
                    selected = goodsDTO[good.Id].Selected;

                GoodDTO.Add(new GoodDTO
                {
                    Name = good.Name,
                    Details = good.Details,
                    Symbol = good.Symbol,
                    Price = good.Price,
                    Selected = selected,
                    Id = good.Id
                });
            });

            return GoodDTO;
        }

        public void AddGood(GoodDTO goodDTO)
        {
            Good good = new Good
            {
                Name = goodDTO.Name,
                Details = goodDTO.Details,
                Symbol = goodDTO.Symbol,
                Price = goodDTO.Price
            };

            _databaseManager.GoodsDao.AddGood(good);

            goodDTO.Name = "";
            goodDTO.Details = "";
            goodDTO.Symbol = "";
            goodDTO.Price = 0;
        }

        public void SaveOrder(OrderDTO orderDTO)
        {
            Order.Details = orderDTO.Details;
            Order.FinishOrderDate = orderDTO.FinishOrderDate;
            Order.StartOrderDate = orderDTO.StartOrderDate;

            _databaseManager.OrdersDao.AddOrder(Order);
        }
    }
}
