﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;
using MusicStore.EntityContext;
using MusicStore.Services;
using MusicStore.Locators;

namespace MusicStore.Controllers
{
    /// <summary>
    ///暂时无法ASP WEB管理器
    ///[Authorize(Roles = "Administrator")]
    /// 这儿没有通过异常抛出实现自定义错误页面
    /// 只是为了学习原生的处理办法 留着备用
    /// </summary>
    [Authorize]
    public class StoreManagerController : Controller
    {
        private readonly IAlbumService albumService = ServiceLocator.AlbumService;
        private readonly IGenreService genreService = ServiceLocator.GenreService;

        // GET: /StoreManager/
        public ActionResult Index()
        {
            var albums = albumService.FindAlbums();
            return View(albums.ToList());
        }

        // GET: /StoreManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = albumService.FindAlbumById(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: /StoreManager/Create
        public ActionResult Create()
        {
            //动态表达式
            //1.传递数据到UI
            //SelectList重要
            ViewBag.ArtistId = new SelectList(albumService.FindAlbums(), "ArtistId", "Name");
            ViewBag.GenreId = new SelectList(genreService.FindGenres(), "GenreId", "Name");
            return View();
        }

        // POST: /StoreManager/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Album album)
        {
            //如果输入正确，符合规则则添加专辑
            //规则来源于实体注解
            //重定向到index
            if (ModelState.IsValid)
            {
                albumService.CreateAlbum(album);
                return RedirectToAction("Index");
            }
            //否则返回Create View并且显示错误信息
            ViewBag.ArtistId = new SelectList(albumService.FindAlbums(), "ArtistId", "Name");
            ViewBag.GenreId = new SelectList(genreService.FindGenres(), "GenreId", "Name");
            return View(album);
        }

        // GET: /StoreManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = albumService.FindAlbumById(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(albumService.FindAlbums(), "ArtistId", "Name");
            ViewBag.GenreId = new SelectList(genreService.FindGenres(), "GenreId", "Name");
            return View(album);
        }

        // POST: /StoreManager/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Album album)
        {
            if (ModelState.IsValid)
            {
                albumService.EditAlbum(album);
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(albumService.FindAlbums(), "ArtistId", "Name");
            ViewBag.GenreId = new SelectList(genreService.FindGenres(), "GenreId", "Name");
            return View(album);
        }

        // GET: /StoreManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = albumService.FindAlbumById(id.Value);
            if (album == null)
            {
                //404方法
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: /StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            albumService.DeleteAlbum(id);
            //采用重定向
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
