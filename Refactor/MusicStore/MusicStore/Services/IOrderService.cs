using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Services
{
    public interface IOrderService : IDisposable
    {
        bool OrderIsExist(Int32 orderId, string userName);
        Order CreateOrder(Order order);
        void EditOrder(Order order);
        void creatOrderDetails(Order order, IEnumerable<Cart> cartItems);
    }
}
