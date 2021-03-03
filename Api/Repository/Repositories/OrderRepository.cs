using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(NotatnikMechanikaDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(dbContext, mapper, httpContextAccessor)
        { }

        public async Task<IEnumerable<OrderExtendedModel>> AllExtendedAsync(bool archived)
        {
            return await DbContext.Orders
                .Include(o => o.Car)
                .ThenInclude(c => c.Customer)
                .Include(o => o.OrderToServices)
                .Include(o => o.OrderToCommodities)
                .OwnedByUser(CurrentUserId)
                .Where(o => o.Archived == archived)
                .Select(o => new OrderExtendedModel
                {
                    Id = o.Id,
                    AcceptDate = o.AcceptDate,
                    FinishDate = o.FinishDate,
                    CarModel = Mapper.Map<CarModel>(o.Car),
                    CustomerModel = Mapper.Map<CustomerModel>(o.Car.Customer),
                    Proggress = ProggressCountHelper(o)
                }).ToListAsync();
        }

        public async Task<OrderExtendedModel> ExtendedAsync(int id, bool archived)
        {
            var queryResult = await DbContext.Orders
                .Include(o => o.Car)
                .ThenInclude(c => c.Customer)
                .SingleAsync(o => o.Archived == archived && o.Id == id);

            return Mapper.Map<OrderExtendedModel>(queryResult);
        }

        public async Task UpdateServiceStatusAsync(Order order, Service service, bool finished)
        {
            var orderToService = await DbContext.OrderToServices.SingleAsync(o => o.Order.Id == order.Id && o.Service.Id == service.Id);
            orderToService.Finished = finished;
            DbContext.OrderToServices.Update(orderToService);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateCommodityStatusAsync(Order order, Commodity commodity, bool finished)
        {
            var orderToCommodity = await DbContext.OrderToCommodities.SingleAsync(o => o.Order.Id == order.Id && o.Commodity.Id == commodity.Id);
            orderToCommodity.Finished = finished;
            DbContext.OrderToCommodities.Update(orderToCommodity);
            await DbContext.SaveChangesAsync();
        }

        private static float ProggressCountHelper(Order order)
        {
            float finished = order.OrderToServices.Count(s => s.Finished) + order.OrderToCommodities.Count(c => c.Finished);
            float count = order.OrderToServices.Count + order.OrderToCommodities.Count;
            return count > 0 ? finished / count : 1;
        }
    }
}
