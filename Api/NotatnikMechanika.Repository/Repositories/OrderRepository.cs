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
    public class OrderRepository : IOrderRepository
    {
        private readonly NotatnikMechanikaDbContext _dbContext;
        public OrderRepository(NotatnikMechanikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckIfUserMatch(int userId, int orderId)
        {
            return await _dbContext.Orders.Where(a => a.UserId == userId).Where(a => a.Id == orderId).AnyAsync();
        }

        public async Task CreateAsync(int userId, OrderModel value)
        {
            await _dbContext.Orders.AddAsync(new Order
            {
                UserId = userId,
                AcceptDate = value.AcceptDate,
                CarId = value.CarId,
                CustomerId = value.CustomerId,
                FinishDate = value.FinishDate
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int orderId)
        {
            _dbContext.Orders.Remove(await _dbContext.Orders.Where(a => a.Id == orderId).FirstOrDefaultAsync());
            await _dbContext.SaveChangesAsync();
        }

        public async Task<OrderModel> GetOrderAsync(int orderId)
        {
            return await _dbContext.Orders.Where(a => a.Id == orderId).Select(value => new OrderModel
            {
                AcceptDate = value.AcceptDate,
                CarId = value.CarId,
                CustomerId = value.CustomerId,
                FinishDate = value.FinishDate
            }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<OrderModel>> GetOrdersAsync(int userId)
        {
            return await _dbContext.Orders.Where(a => a.UserId == userId).Select(value => new OrderModel
            {
                AcceptDate = value.AcceptDate,
                CarId = value.CarId,
                CustomerId = value.CustomerId,
                FinishDate = value.FinishDate
            }).ToListAsync();
        }

        public async Task UpdateAsync(int orderId, OrderModel value)
        {
            Order order = await _dbContext.Orders.Where(a => a.Id == orderId).FirstOrDefaultAsync();

            order.AcceptDate = value.AcceptDate;
            order.CarId = value.CarId;
            order.CustomerId = value.CustomerId;
            order.FinishDate = value.FinishDate;

            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();
        }
    }
}
