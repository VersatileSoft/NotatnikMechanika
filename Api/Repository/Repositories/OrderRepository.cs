using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotatnikMechanika.Shared.Models.Commodity;
using Microsoft.AspNetCore.Http;

namespace NotatnikMechanika.Repository.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(NotatnikMechanikaDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(dbContext, mapper, httpContextAccessor)
        { }

        public async Task AddCommodityToOrder(int orderId, Commodity commodity)
        {
            (await DbContext.Orders.Include(o => o.Commodities).SingleAsync(o => o.Id == orderId)).Commodities.Add(commodity);
            await DbContext.SaveChangesAsync();
        }

        public async Task AddServiceToOrder(int orderId, Service service)
        {
            (await DbContext.Orders.Include(o => o.Services).SingleAsync(o => o.Id == orderId)).Services.Add(service);
            await DbContext.SaveChangesAsync();
        }

        public Task<bool> IsCommodityInOrder(int orderId, int commodityId)
        {
            return DbContext.OrderToCommodities.AnyAsync(c => c.Commodity.Id == commodityId && c.Order.Id == orderId);
        }

        public Task<bool> IsServiceInOrder(int orderId, int serviceId)
        {
            return DbContext.OrderToServices.AnyAsync(c => c.Service.Id == serviceId && c.Order.Id == orderId);
        }

        public async Task DeleteCommodityFromOrder(int orderId, Commodity commodity)
        {
            (await DbContext.Orders.Include(o => o.Commodities).SingleAsync(o => o.Id == orderId)).Commodities.Remove(commodity);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteServiceFromOrder(int orderId, Service service)
        {
            (await DbContext.Orders.Include(o => o.Services).SingleAsync(o => o.Id == orderId)).Services.Remove(service);
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderExtendedModel>> AllExtendedAsync(bool archived)
        {
            var queryResult = await DbContext.Orders
                .Include(o => o.Car)
                .ThenInclude(c => c.Customer)
                .OwnedByUser(CurrentUserId)
                .Where(o => o.Archived == archived)
                .ToListAsync();

            return Mapper.Map<IEnumerable<OrderExtendedModel>>(queryResult);
        }

        public async Task<OrderExtendedModel> ExtendedAsync(int id, bool archived)
        {
            var queryResult = await DbContext.Orders
                .Include(o => o.Car)
                .ThenInclude(c => c.Customer)
                .SingleAsync(o => o.Archived == archived && o.Id == id);

            return Mapper.Map<OrderExtendedModel>(queryResult);
        }
    }
}
