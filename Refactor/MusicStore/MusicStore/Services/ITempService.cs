using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MusicStore.Services
{
    public interface ITempService
    {
        //HomeController
        IEnumerable<Album> GetTopSellingAlbums(int count);
        //StoreController
        Genre FindGenreByName(string genreName);
        IEnumerable<Genre> FindGenres();
        Album FindAlbumById(Int32 id);
        //StoreManagerController
        IEnumerable<Album> FindAlbums();
        void CreateAlbum(Album album);
        void EditAlbum(Album album);
        void DeleteAlbum(Int32 id);
        //CheckoutController
        bool AddressAndPayment(Order order, string userName);
        bool OrderIsValid(Int32 orderId, string userName);
        //ShoppingCartController
        string FindCartAlbumTitle(Int32 cartRecordId);
        //ShoppingCart
        Cart FindCartByCartIdAndAlbumId(string shoppingCartId, Int32 albumId);
        Cart FindCartByCartIdAndRecordId(string cartId,Int32 recordId);
        IEnumerable<Cart> FindCartItemsByCartId(string cartId);
        void DeleteCart(IEnumerable<Cart> carts);
        int? StaticAlbumCount(string cartId);
        decimal? StaticTotalMoney(string cartId);
        void InitialAndCreatCart(Album album, string shoppingCartId);
        void EditCart(Cart cart);
        Order CreateOrder(Order order);
        void EditOrder(Order order);
        bool OrderIsExist(Int32 orderId, string userName);
        void InitialUpdateOrderAndCreatOrderDetails(Order order,IEnumerable<Cart> cartItems);
        void AddToCart(Album album, string shoppingCartId);
        int RemoveFromCart(int recordId);
        void EmptyCart();
        int GetCount();
        decimal GetTotal();
        int CreateOrder(Order order);
        string GetCartId(HttpContextBase context);
        void MigrateCart(string userName);
    }
}
