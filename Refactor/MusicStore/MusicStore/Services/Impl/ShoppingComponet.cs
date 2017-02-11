using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Services.Impl
{
    public class ShoppingComponet : IShoppingComponet
    {
        private readonly IShopCartService shopCartService;
        private readonly IOrderService orderService;
        public ShoppingComponet(IShopCartService shopCartService,IOrderService orderService)
        {
            this.shopCartService = shopCartService;
            this.orderService = orderService;
        }
        //存在Session中的键值 保存ShoppingCartId
        private  const string cartSessionKey = "CartId";

        public string CartSessionKey
        {
            get { return cartSessionKey; }
        }

        public void AddToCart(Album album, string shoppingCartId)
        {
            // Get the matching cart and album instances
            var cartItem = shopCartService.FindCartByCartIdAndAlbumId(shoppingCartId, album.AlbumId);
            if (cartItem == null)
            {
                shopCartService.InitialAndCreatCart(album, shoppingCartId);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.Count++;
                shopCartService.EditCart(cartItem);
            }
        }
        public int RemoveFromCart(string shoppingCartId,int recordId)
        {
            // Get the cart
            var cartItem = shopCartService.FindCartByCartIdAndRecordId(shoppingCartId, recordId);
            int itemCount = 0;
            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                    shopCartService.EditCart(cartItem);
                }
                else
                {
                    shopCartService.DeleteCart(cartItem);
                }
            }
            return itemCount;
        }
        public void EmptyCart(string shoppingCartId)
        {
            var cartItems = shopCartService.FindCartItemsByCartId(shoppingCartId);
            shopCartService.DeleteCart(cartItems);
        }
        public List<Cart> GetCartItems(string shoppingCartId)
        {
            return shopCartService.FindCartItemsByCartId(shoppingCartId).ToList();
        }
        public int GetCount(string shoppingCartId)
        {
            // Get the count of each item in the cart and sum them up
            int? count = shopCartService.StaticAlbumCount(shoppingCartId);
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetTotal(string shoppingCartId)
        {
            // Multiply album price by count of that album to get
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = shopCartService.StaticTotalMoney(shoppingCartId);
            return total ?? 0;
        }
        public int CreateOrder(Order order, string shoppingCartId)
        {
            var cartItems = GetCartItems(shoppingCartId);
            orderService.InitialUpdateOrderAndCreatOrderDetails(order, cartItems);
            // Empty the shopping cart
            EmptyCart(shoppingCartId);
            // Return the OrderId as the confirmation number
            return order.OrderId;

        }
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[cartSessionKey] == null)
            {
                if (!string.IsNullOrEmpty(context.User.Identity.Name))
                {
                    context.Session[cartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[cartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[cartSessionKey].ToString();
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string ShoppingCartId,string userName)
        {
            var shoppingCart = shopCartService.FindCartItemsByCartId(ShoppingCartId);
            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
                shopCartService.EditCart(item);
            }
        }
    }
}