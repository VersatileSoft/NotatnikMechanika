using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotatnikMechanika.Core.Models;
using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Car;
using NotatnikMechanika.Shared.Models.Customer;
using NotatnikMechanika.Shared.Models.Order;

namespace NotatnikMechanika.Repository.Repositories
{
    public class OrderRepository : RepositoryBase<OrderModel, Order>, IOrderRepository
    {
        public OrderRepository(NotatnikMechanikaDbContext dbContext) : base(dbContext)
        { }

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
