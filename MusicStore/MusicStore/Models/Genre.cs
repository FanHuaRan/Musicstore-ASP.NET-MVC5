using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    /// <summary>
    /// 流派
    /// 2017/1/20 fhr
    /// </summary>
    public class Genre
    {
        public Int32 GenreId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Album> Albums { get; set; }
    }
}