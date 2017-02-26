using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStore.Models;
using MusicStore.EntityContext;
namespace MusicStore.Services.Impl
{
    public class CheckoutServiceClass:ICheckoutService
    {
        private readonly IOrderService orderService;
        private const string PromoCode="FREE";
        public CheckoutServiceClass(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        public bool AddressAndPayment(ref Order order,ShoppingCart cart,string userName,string userPromoCode)
        {
            try
            {
                //judge PromoCode
                if (!string.Equals(userPromoCode, PromoCode, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                else
                {
                    order.Username = userName;
                    order.OrderDate = DateTime.Now;
                    order.Total = cart.GetTotal();
                    order=orderService.CreateOrder(order);
                    orderService.creatOrderDetails(order, cart.GetCartItems());
                    cart.EmptyCart();
                    return true;
                }
            }
            catch
            {
                //Invalid - redisplay with errors
                return false;
            }
        }

        public bool OrderIsValid(int orderId, string userName)
        {
            bool isValid = orderService.OrderIsExist(orderId, userName);
            return isValid;
        }
    }
}