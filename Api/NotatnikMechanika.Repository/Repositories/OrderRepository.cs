using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Order;

namespace NotatnikMechanika.Repository.Repositories
{
    public class OrderRepository : RepositoryBase<OrderModel, Order>, IOrderRepository
    {
        public OrderRepository(NotatnikMechanikaDbContext dbContext) : base(dbContext)
        { }
    }
}
