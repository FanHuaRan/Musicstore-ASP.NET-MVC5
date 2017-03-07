using log4net;
using log4net.Repository.Hierarchy;
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
    public class HomeController : Controller
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(HomeController));

        private readonly IAlbumService albumService = ServiceLocator.AlbumService;
        //
        // GET: /Home/
        public ActionResult Index()
        {
            // Get most popular albums
            var albums = albumService.GetTopSellingAlbums(5);
          //  throw new Exception();
            return View(albums);
        }

        public ActionResult NoAuth()
        {
            return View("NoAuth");
        }
        public ActionResult NoFound()
        {
            return View("NoFound");
        }
	}
}