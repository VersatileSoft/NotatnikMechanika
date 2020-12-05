﻿using NotatnikMechanika.Api.Data.Models;
using NotatnikMechanika.Api.Repository.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Api.Repository.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<IEnumerable<OrderExtendedModel>> AllExtendedAsync(string userId, bool archived);
        Task AddCommodityToOrder(int orderId, Commodity commodity);
        Task AddServiceToOrder(int orderId, Service service);
        Task DeleteServiceFromOrder(int orderId, Service service);
        Task DeleteCommodityFromOrder(int orderId, Commodity commodity);
        Task<bool> IsCommodityInOrder(int orderId, int commodityId);
        Task<bool> IsServiceInOrder(int orderId, int serviceId);
        Task<OrderExtendedModel> ExtendedAsync(int id, bool archived);
    }
}
