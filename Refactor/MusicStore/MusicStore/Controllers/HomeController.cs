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
        private IAlbumService albumService = ServiceLocator.AlbumService;
        //
        // GET: /Home/
        public ActionResult Index()
        {
            // Get most popular albums
            var albums = albumService.GetTopSellingAlbums(5);
            return View(albums);
        }
      
	}
}