using Microsoft.EntityFrameworkCore;
using NotatnikMechanika.Core.Models;
using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Car;
using NotatnikMechanika.Shared.Models.Customer;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Repositories
{
    public class OrderRepository : RepositoryBase<OrderModel, Order>, IOrderRepository
    {
        public OrderRepository(NotatnikMechanikaDbContext dbContext) : base(dbContext)
        { }

        public Task AddCommodityToOrder(int orderId, int commodityId)
        {
            _dbContext.OrderToCommodities.Add(new OrderToCommodity
            {
                CommodityId = commodityId,
                OrderId = orderId
            });

            return _dbContext.SaveChangesAsync();
        }

        public Task AddServiceToOrder(int orderId, int serviceId)
        {
            _dbContext.OrderToServices.Add(new OrderToService
            {
                ServiceId = serviceId,
                OrderId = orderId
            });

            return _dbContext.SaveChangesAsync();
        }

        public Task<bool> CheckIfOrderToCommodityExsist(int orderId, int commodityId)
        {
            return _dbContext.OrderToCommodities.Where(a => a.OrderId == orderId).Where(c => c.CommodityId == commodityId).AnyAsync();
        }

        public Task<bool> CheckIfOrderToServiceExsist(int orderId, int serviceId)
        {
            return _dbContext.OrderToServices.Where(a => a.OrderId == orderId).Where(c => c.ServiceId == serviceId).AnyAsync();
        }

        public async Task DeleteCommodityFromOrder(int orderId, int commodityId)
        {
            _dbContext.OrderToCommodities.Remove(await _dbContext.OrderToCommodities.Where(a => a.OrderId == orderId).Where(c => c.CommodityId == commodityId).FirstOrDefaultAsync());
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteServiceFromOrder(int orderId, int serviceId)
        {
            _dbContext.OrderToServices.Remove(await _dbContext.OrderToServices.Where(a => a.OrderId == orderId).Where(c => c.ServiceId == serviceId).FirstOrDefaultAsync());
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderExtendedModel>> GetAllExtendedAsync(string userId, bool archived)
        {
            return await (from orders in _dbContext.Orders
                          join cars in _dbContext.Cars on orders.CarId equals cars.Id
                          join customers in _dbContext.Customers on cars.CustomerId equals customers.Id
                          where orders.UserId == userId
                          where orders.Archived == archived
                          select new OrderExtendedModel
                          {
                              Id = orders.Id,
                              CarModel = new CarModel
                              {
                                  Brand = cars.Brand,
                                  CustomerId = cars.CustomerId,
                                  Engine = cars.Engine,
                                  Id = cars.Id,
                                  Model = cars.Model,
                                  Plate = cars.Plate,
                                  Power = cars.Power,
                                  Vin = cars.Vin
                              },
                              CustomerModel = new CustomerModel
                              {
                                  Address = customers.Address,
                                  CompanyIdentyficator = customers.CompanyIdentyficator,
                                  CompanyName = customers.CompanyName,
                                  Id = customers.Id,
                                  Name = customers.Name,
                                  Phone = customers.Phone,
                                  Surname = customers.Surname
                              },
                              AcceptDate = orders.AcceptDate,
                              FinishDate = orders.FinishDate
                          }).ToListAsync();
        }
    }
}
