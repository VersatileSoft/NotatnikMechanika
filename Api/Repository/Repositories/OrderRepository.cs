﻿using AutoMapper;
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
using NotatnikMechanika.Shared.Models.Car;
using NotatnikMechanika.Shared.Models.Customer;

namespace NotatnikMechanika.Repository.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(NotatnikMechanikaDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(dbContext, mapper, httpContextAccessor)
        { }

        public Task<bool> IsCommodityInOrder(int orderId, int commodityId)
        {
            return DbContext.OrderToCommodities.AnyAsync(c => c.Commodity.Id == commodityId && c.Order.Id == orderId);
        }

        public Task<bool> IsServiceInOrder(int orderId, int serviceId)
        {
            return DbContext.OrderToServices.AnyAsync(c => c.Service.Id == serviceId && c.Order.Id == orderId);
        }

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

        private static float ProggressCountHelper(Order order)
        {
            float finished = order.OrderToServices.Count(s => s.Finished) + order.OrderToCommodities.Count(c => c.Finished);
            float count = order.OrderToServices.Count + order.OrderToCommodities.Count;
            return count > 0 ? finished / count : 1;
        }

        public async Task<OrderExtendedModel> ExtendedAsync(int id, bool archived)
        {
            var queryResult = await DbContext.Orders
                .Include(o => o.Car)
                .ThenInclude(c => c.Customer)
                .SingleAsync(o => o.Archived == archived && o.Id == id);

            return Mapper.Map<OrderExtendedModel>(queryResult);
        }

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

        public async Task UpdateServiceStatusAsync(int orderId, int serviceId, bool finished)
        {
            var orderToService = await DbContext.OrderToServices.SingleAsync(o => o.Order.Id == orderId && o.Service.Id == serviceId);
            orderToService.Finished = finished;
            DbContext.OrderToServices.Update(orderToService);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateCommodityStatusAsync(int orderId, int commodityId, bool finished)
        {
            var orderToCommodity = await DbContext.OrderToCommodities.SingleAsync(o => o.Order.Id == orderId && o.Commodity.Id == commodityId);
            orderToCommodity.Finished = finished;
            DbContext.OrderToCommodities.Update(orderToCommodity);
            await DbContext.SaveChangesAsync();
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
    }
}
