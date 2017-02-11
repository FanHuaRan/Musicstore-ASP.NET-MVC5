using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Services
{
    public interface IAlbumService:IDisposable
    {
        IEnumerable<Album> GetTopSellingAlbums(int count);
        Album FindAlbumById(Int32 id);
        IEnumerable<Album> FindAlbums();
        void CreateAlbum(Album album);
        void EditAlbum(Album album);
        void DeleteAlbum(Int32 id);
    }
}
