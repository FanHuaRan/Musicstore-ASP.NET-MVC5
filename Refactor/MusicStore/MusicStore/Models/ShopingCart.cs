using MusicStore.EntityContext;
using MusicStore.Locators;
using MusicStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private static IShoppingComponet shoppingComponet=ServiceLocator.ShoppingComponet;
        public static IShoppingComponet ShoppingComponet
        {
            get
            {
                return shoppingComponet;
            }
            set
            {
                shoppingComponet = value;
            }
        }
        public  string ShoppingCartId { get; set; }
        private ShoppingCart()
        {

        }
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        public void AddToCart(Album album)
        {
            // Get the matching cart and album instances
            shoppingComponet.AddToCart(album, ShoppingCartId);
        }
        public int RemoveFromCart(int recordId)
        {
            // Get the cart
            return shoppingComponet.RemoveFromCart(ShoppingCartId, recordId);
        }
        public void EmptyCart()
        {
            shoppingComponet.EmptyCart(ShoppingCartId);
        }
        public List<Cart> GetCartItems()
        {
            return shoppingComponet.GetCartItems(ShoppingCartId);
        }
        public int GetCount()
        {
            return shoppingComponet.GetCount(ShoppingCartId);
        }
        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            return shoppingComponet.GetTotal(ShoppingCartId);
        }
        public int CreateOrder(Order order)
        {
            return shoppingComponet.CreateOrder(order,ShoppingCartId);

        }
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            return shoppingComponet.GetCartId(context);
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            shoppingComponet.MigrateCart(ShoppingCartId, userName);
        }

        public static string CartSessionKey { get { return shoppingComponet.CartSessionKey; } }
    }
}