using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Services
{
    public interface IShopCartService : IDisposable
    {
        string FindCartAlbumTitle(Int32 cartRecordId);
        Cart FindCartByCartIdAndAlbumId(string cartId, Int32 albumId);
        Cart FindCartByCartIdAndRecordId(string cartId, Int32 recordId);
        IEnumerable<Cart> FindCartItemsByCartId(string cartId);
        void DeleteCart(IEnumerable<Cart> carts);
        void DeleteCart(Cart cart);
        int? StaticAlbumCount(string cartId);
        decimal? StaticTotalMoney(string cartId);
        void InitialAndCreatCart(Album album, string shoppingCartId);
        void EditCart(Cart cart);
    }
}
