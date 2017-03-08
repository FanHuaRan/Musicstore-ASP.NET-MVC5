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
    /// <summary>
    /// 对于错误请求全部进行了异常抛出
    /// </summary>
    public class StoreController : Controller
    {
        private readonly IGenreService genreService = ServiceLocator.GenreService;
        private readonly IAlbumService albumService = ServiceLocator.AlbumService;
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
            if (string.IsNullOrEmpty(genre))
            {
                //采用异常抛出 否则不能实现自定义错误页面
                throw new HttpException(400, "Bad Request");
            }
            var example = genreService.FindGenreByName(genre);
            if (example == null)
            {
                throw new HttpException(404, "Wrong Url");
            }
            return View(example);
        }
        //
        // GET: /Store/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //采用异常抛出 否则不能实现自定义错误页面
                throw new HttpException(400,"Bad Request");
              //  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = albumService.FindAlbumById(id.Value);
            if (album == null)
            {
                throw new HttpException(404, "Wrong Url");
               // return HttpNotFound();
            }
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