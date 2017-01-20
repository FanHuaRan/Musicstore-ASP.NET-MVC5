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
        public  Int64 AlbumId { get; set; }

        public Int32 GenreId { get; set; }

        public Int64 ArtistId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string AlbumArtUrl { get; set; }

        public Artist Artist { get; set; }

        public Genre Genre { get; set; }
    }
}