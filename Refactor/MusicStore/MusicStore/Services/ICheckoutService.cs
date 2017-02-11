using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Services
{
    public interface ICheckoutService
    {
        bool AddressAndPayment(ref Order order, string userName, string userPromoCode);
        bool OrderIsValid(Int32 orderId, string userName);
    }
}
