using MusicStore.EntityContext;
using MusicStore.Locators;
using MusicStore.Models;
using MusicStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        IGenreService genreService = ServiceLocator.GenreService;
        IAlbumService albumService = ServiceLocator.AlbumService;
        //
        // GET: /Store/
        public ActionResult Index()
        {
            var genres = genreService.FindGenres();
            return View(genres);
        }
        //
        // GET: /Store/Browse
        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            //Include("Albums")指定返回结果要包含关联Album
            var example = genreService.FindGenreByName(genre);
            return View(example);
        }
        //
        // GET: /Store/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = albumService.FindAlbumById(id.Value);
            return View(album);
        }
        //
        // GET: /Store/GenreMenu
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = genreService.FindGenres();
            return PartialView(genres);
        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        genreService.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
	}
}