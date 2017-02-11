using System;
namespace MusicStore.Services
{
    public interface IShoppingComponet
    {
        void AddToCart(MusicStore.Models.Album album, string shoppingCartId);
        int CreateOrder(MusicStore.Models.Order order, string shoppingCartId);
        void EmptyCart(string shoppingCartId);
        string GetCartId(System.Web.HttpContextBase context);
        System.Collections.Generic.List<MusicStore.Models.Cart> GetCartItems(string shoppingCartId);
        int GetCount(string shoppingCartId);
        decimal GetTotal(string shoppingCartId);
        void MigrateCart(string ShoppingCartId, string userName);
        int RemoveFromCart(string shoppingCartId, int recordId);
        string CartSessionKey { get; }
    }
}
