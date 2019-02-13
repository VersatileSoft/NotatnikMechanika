using NotatnikMechanika.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotatnikMechanika.Model.Interfaces
{
    public class OrdersDao
    {
        public void AddOrder(OrderDTO orderDTO)
        {
            using (var db = new MainEntities())
            {
                Order order = new Order
                {
                    Id = db.Orders.Count(),
                    Archived = 0,
                    CarId = orderDTO.CarId,
                    CustomerId = orderDTO.CustomerId,
                    Details = orderDTO.Details,
                    FinishOrderDate = orderDTO.FinishOrderDate,
                    StartOrderDate = orderDTO.StartOrderDate
                };

                db.Orders.Add(order);

                db.SaveChanges();

                foreach (int id in orderDTO.ServicesIds)
                {
                    OrdersToService orderToService = new OrdersToService()
                    {
                        Id = db.OrdersToServices.Count(),
                        OrderId = order.Id,
                        ServiceId = id
                    };
                    db.OrdersToServices.Add(orderToService);
                    db.SaveChanges();
                }

                foreach (int id in orderDTO.GoodsIds)
                {
                    OrdersToGood orderToGood = new OrdersToGood()
                    {
                        Id = db.OrdersToGoods.Count(),
                        OrderId = order.Id,
                        GoodId = id
                    };
                    db.OrdersToGoods.Add(orderToGood);
                    db.SaveChanges();
                }

                db.Dispose();
            }
        }

        public void UpdateOrder(Order order)
        {
            throw (new NotImplementedException());
        }

        public void DeleteOrder(Order order)
        {
            throw (new NotImplementedException());
        }

        public List<OrderPresenter> GetOrders()
        {
            List<Order> orders = new List<Order>();
            List<OrderPresenter> orderPresenters = new List<OrderPresenter>();

            using (var db = new MainEntities())
            {

                orderPresenters = (from tOrders in db.Orders
                                   join tCars in db.Cars on tOrders.CarId equals tCars.Id
                                   join tCustomers in db.Customers on tOrders.CustomerId equals tCustomers.Id
                                   select new OrderPresenter
                                   {
                                       Car = tCars,
                                       Customer = tCustomers,
                                       Details = tOrders.Details,
                                       FinishOrderDate = tOrders.FinishOrderDate,
                                       StartOrderDate = tOrders.StartOrderDate
                                   }).ToList();
                db.Dispose();

            }
            return orderPresenters;
        }
    }
}