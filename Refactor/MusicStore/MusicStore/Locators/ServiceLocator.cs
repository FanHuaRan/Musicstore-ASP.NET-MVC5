using MusicStore.Services;
using MusicStore.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Locators
{
    public class ServiceLocator
    {
        public static IAlbumService AlbumService
        {
            get
            {
                return new AlbumServiceClass();
            }
        }
        public static ICheckoutService CheckoutService
        {
            get
            {
                return new CheckoutServiceClass(new OrderServiceClass());
            }
        }
        public static IGenreService GenreService
        {
            get
            {
                return new GenreServiceClass();
            }
        }
        public static IOrderService OrderService
        {
            get
            {
                return new OrderServiceClass();
            }
        }
        public static IShopCartService ShopCartService
        {
            get
            {
                return new ShopCartServiceClass();
            }
        }
        public static IShoppingComponet ShoppingComponet
        {
            get
            {
                return new ShoppingComponet(new ShopCartServiceClass(), new OrderServiceClass());
            }
        }
    }
}