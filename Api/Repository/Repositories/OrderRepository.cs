using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Repositories
{
    public class OrderRepository : RepositoryBase<OrderModel, Order>, IOrderRepository
    {
        public OrderRepository(NotatnikMechanikaDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
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
            List<Order> queryResult = await _dbContext.Orders
                .Include(o => o.Car)
                .ThenInclude(c => c.Customer)
                .Where(o => o.UserId == userId)
                .Where(o => o.Archived == archived)
                .ToListAsync();

            return _mapper.Map<IEnumerable<OrderExtendedModel>>(queryResult);
        }

        public async Task<OrderExtendedModel> GetExtendedAsync(string userId, int id, bool archived)
        {
            Order queryResult = await _dbContext.Orders
                .Include(o => o.Car)
                .ThenInclude(c => c.Customer)
                .Where(o => o.UserId == userId)
                .Where(o => o.Archived == archived)
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<OrderExtendedModel>(queryResult);
        }
    }
}
