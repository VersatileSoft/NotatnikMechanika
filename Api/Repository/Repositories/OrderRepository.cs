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
            DbContext.OrderToCommodities.Add(new OrderToCommodity
            {
                CommodityId = commodityId,
                OrderId = orderId
            });

            return DbContext.SaveChangesAsync();
        }

        public Task AddServiceToOrder(int orderId, int serviceId)
        {
            DbContext.OrderToServices.Add(new OrderToService
            {
                ServiceId = serviceId,
                OrderId = orderId
            });

            return DbContext.SaveChangesAsync();
        }

        public Task<bool> CheckIfOrderToCommodityExsist(int orderId, int commodityId)
        {
            return DbContext.OrderToCommodities.Where(a => a.OrderId == orderId).Where(c => c.CommodityId == commodityId).AnyAsync();
        }

        public Task<bool> CheckIfOrderToServiceExsist(int orderId, int serviceId)
        {
            return DbContext.OrderToServices.Where(a => a.OrderId == orderId).Where(c => c.ServiceId == serviceId).AnyAsync();
        }

        public async Task DeleteCommodityFromOrder(int orderId, int commodityId)
        {
            DbContext.OrderToCommodities.Remove(await DbContext.OrderToCommodities.Where(a => a.OrderId == orderId).Where(c => c.CommodityId == commodityId).FirstOrDefaultAsync());
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteServiceFromOrder(int orderId, int serviceId)
        {
            DbContext.OrderToServices.Remove(await DbContext.OrderToServices.Where(a => a.OrderId == orderId).Where(c => c.ServiceId == serviceId).FirstOrDefaultAsync());
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderExtendedModel>> AllExtendedAsync(string userId, bool archived)
        {
            var queryResult = await DbContext.Orders
                .Include(o => o.Car)
                .ThenInclude(c => c.Customer)
                .Where(o => o.UserId == userId)
                .Where(o => o.Archived == archived)
                .ToListAsync();

            return Mapper.Map<IEnumerable<OrderExtendedModel>>(queryResult);
        }

        public async Task<OrderExtendedModel> ExtendedAsync(string userId, int id, bool archived)
        {
            var queryResult = await DbContext.Orders
                .Include(o => o.Car)
                .ThenInclude(c => c.Customer)
                .Where(o => o.UserId == userId)
                .Where(o => o.Archived == archived)
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            return Mapper.Map<OrderExtendedModel>(queryResult);
        }
    }
}
