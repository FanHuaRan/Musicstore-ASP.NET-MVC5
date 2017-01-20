using MusicStore.EntityFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        MyContext context = MyContext.Context;
        //
        // GET: /Store/
        public ActionResult Index()
        {
            var genre = context.Genres.ToList();
            return View(genre);
        }
        //
        // GET: /Store/Browse
        public string Browse()
        {
            return "Hello from Store.Browse()";
        }
        //
        // GET: /Store/Details
        public string Details()
        {
            return "Hello from Store.Details()";
        }
	}
}