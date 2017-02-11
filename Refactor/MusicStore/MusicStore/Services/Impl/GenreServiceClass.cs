using MusicStore.EntityContext;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using System.Data;
using System.Data.Entity;
namespace MusicStore.Services.Impl
{
    public class GenreServiceClass:IGenreService
    {
        private readonly MusicStoreEntities storeDB = new MusicStoreEntities();
        public Genre FindGenreByName(string genreName)
        {
            return storeDB.Genres
                .Include(p=>p.Albums)
                .Where(p => p.Name == genreName)
                .SingleOrDefault();
        }

        public IEnumerable<Genre> FindGenres()
        {
            return storeDB.Genres.ToList();
        }
        public void Dispose()
        {
            storeDB.Dispose();
        }
    }
}