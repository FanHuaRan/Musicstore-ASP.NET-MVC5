using MusicStore.EntityContext;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace MusicStore.Services.Impl
{
    public class ShopCartServiceClass:IShopCartService
    {
        private MusicStoreEntities storeDB = new MusicStoreEntities();
        public string FindCartAlbumTitle(int cartRecordId)
        {
            Cart cart = storeDB.Carts.Include(p => p.Album)
                .SingleOrDefault(p => p.RecordId == cartRecordId);
            if (cart != null)
            {
                return cart.Album.Title;
            }
            return "";
        }

        public Cart FindCartByCartIdAndAlbumId(string cartId, Int32 albumId)
        {
            return storeDB.Carts.SingleOrDefault(
                  c => c.CartId == cartId
                  && c.AlbumId == albumId);
        }

        public Models.Cart FindCartByCartIdAndRecordId(string cartId, Int32 recordId)
        {
            return storeDB.Carts.Single(
                cart => cart.CartId == cartId
                && cart.RecordId == recordId);
        }

        public IEnumerable<Models.Cart> FindCartItemsByCartId(string cartId)
        {
            return storeDB.Carts.Include(p=>p.Album)
                .Where(cart => cart.CartId == cartId);
        }

        public void DeleteCart(IEnumerable<Models.Cart> carts)
        {
            foreach (var cartItem in carts)
            {
                storeDB.Carts.Remove(cartItem);
            }
            storeDB.SaveChanges(); ;
        }

        public int? StaticAlbumCount(string cartId)
        {
            Int32? count = (from cartItems in storeDB.Carts
                            where cartItems.CartId == cartId
                          select (int?)cartItems.Count)
                          .Sum();
            return count;
        }

        public decimal? StaticTotalMoney(string cartId)
        {
            decimal? total = (from cartItem in storeDB.Carts
                              where cartItem.CartId == cartId
                              select (int?)cartItem.Count * cartItem.Album.Price)
                              .Sum();
            return total;
        }

        public void InitialAndCreatCart(Models.Album album, string shoppingCartId)
        {
            // Create a new cart item if no cart item exists
            var cartItem = new Cart()
            {
                AlbumId = album.AlbumId,
                CartId = shoppingCartId,
                Count = 1,
                DateCreated = DateTime.Now
            };
            storeDB.Carts.Add(cartItem);
            storeDB.SaveChanges();
        }

        public void EditCart(Models.Cart cart)
        {
            storeDB.Entry(cart).State = EntityState.Modified;
            storeDB.SaveChanges();
        }


        public void DeleteCart(Cart cart)
        {
            storeDB.Carts.Remove(cart);
            storeDB.SaveChanges();
        }
        public void Dispose()
        {
            storeDB.Dispose();
        }
    }
}