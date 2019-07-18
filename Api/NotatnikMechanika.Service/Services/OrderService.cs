using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Service.Exception;
using NotatnikMechanika.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Order;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Services
{
    public class OrderService : ServiceBase<OrderModel>, IOrderService
    {
        public OrderService(IOrderRepository orderRepository) : base(orderRepository)
        {
        }
    }
}
