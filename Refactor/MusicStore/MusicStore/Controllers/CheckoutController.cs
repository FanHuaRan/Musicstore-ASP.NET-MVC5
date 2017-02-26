using MusicStore.EntityContext;
using MusicStore.Locators;
using MusicStore.Models;
using MusicStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ICheckoutService CheckOutService = ServiceLocator.CheckoutService;
        //
        // GET: /Checkout/
        public ActionResult AddressAndPayment()
        {
            return View();
        }
        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);
            var cart = ShoppingCart.GetCart(this.HttpContext);
            order.Total = cart.GetTotal();
            if(CheckOutService.AddressAndPayment(ref order, cart,User.Identity.Name, values["PromoCode"]))
            {
                    //Process the order
                   // var cart = ShoppingCart.GetCart(this.HttpContext);
                   // cart.CreateOrder(order);
                    return RedirectToAction("Complete", new { id = order.OrderId });
            }
            else
            {
                return View(order);
            }
        }
        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = CheckOutService.OrderIsValid(id, User.Identity.Name);
            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
	}
}