using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MusicStore.Services
{
    public interface IShoppingCart
    {
        void AddToCart(Album album);
        int RemoveFromCart(int recordId);
        void EmptyCart();
        int GetCount();
        decimal GetTotal();
        int CreateOrder(Order order);
        string GetCartId(HttpContextBase context);
        void MigrateCart(string userName);
    }
}
