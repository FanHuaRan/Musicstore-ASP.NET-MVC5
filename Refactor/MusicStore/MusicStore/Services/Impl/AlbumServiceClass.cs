using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using MusicStore.Models;
using MusicStore.EntityContext;
namespace MusicStore.Services.Impl
{
    public class AlbumServiceClass:IAlbumService
    {
        private readonly MusicStoreEntities storeDB = new MusicStoreEntities();
        public IEnumerable<Models.Album> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count
            return storeDB.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }

        public Models.Album FindAlbumById(Int32 id)
        {
            return storeDB.Albums.Find(id);
        }

        public IEnumerable<Models.Album> FindAlbums()
        {
            return storeDB.Albums.Include(a => a.Artist).Include(a => a.Genre);
        }

        public void CreateAlbum(Models.Album album)
        {
            storeDB.Albums.Add(album);
            storeDB.SaveChanges();
        }

        public void EditAlbum(Models.Album album)
        {
            storeDB.Entry(album).State = EntityState.Modified;
            storeDB.SaveChanges();
        }

        public void DeleteAlbum(int id)
        {
            Album album = storeDB.Albums.Find(id);
            storeDB.Albums.Remove(album);
            storeDB.SaveChanges();
        }

        public void Dispose()
        {
            storeDB.Dispose();
        }
    }
}