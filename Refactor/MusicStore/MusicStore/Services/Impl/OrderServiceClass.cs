using MusicStore.EntityContext;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicStore.Services.Impl
{
    public class OrderServiceClass:IOrderService
    {
        private readonly MusicStoreEntities storeDB = new MusicStoreEntities();
        public bool OrderIsExist(int orderId, string userName)
        {
            return storeDB.Orders.Any(o => o.OrderId == orderId
                                      && o.Username == userName);
        }

        public Order CreateOrder(Models.Order order)
        {
            order=storeDB.Orders.Add(order);
            storeDB.SaveChanges();
            return order;
        }

        public void EditOrder(Models.Order order)
        {
            storeDB.Entry(order).State = EntityState.Modified;
            storeDB.SaveChanges();
        }

        public void InitialUpdateOrderAndCreatOrderDetails(Models.Order order, IEnumerable<Models.Cart> cartItems)
        {
            //order have create and is going to update information
            decimal orderTotal = 0;
            // Iterate over the items in the cart, adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    AlbumId = item.AlbumId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Album.Price,
                    Quantity = item.Count
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Album.Price);
                storeDB.OrderDetails.Add(orderDetail);
            }
            // Set the order's total to the orderTotal count
            order.Total = orderTotal;
            // Save the order
            storeDB.SaveChanges();
        }
        public void Dispose()
        {
            storeDB.Dispose();
        }
    }
}