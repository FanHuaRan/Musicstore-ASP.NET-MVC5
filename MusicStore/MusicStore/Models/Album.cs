using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    /// <summary>
    /// 专辑模型
    /// 2017/1/20 fhr 
    /// </summary>
    public class Album
    {
        public  int AlbumId { get; set; }

        public int GenreId { get; set; }

        public int ArtistId { get; set; }

        public string Title { get; set; }

        public float Price { get; set; }

        public string AlbumArtUrl { get; set; }

      //  public 
    }
}