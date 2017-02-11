using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    /// <summary>
    /// 购物车条目记录
    /// </summary>
    public class Cart
    {
        //主键注解
        [Key]
        public int RecordId { get; set; }
        //一般是姓名 或者随机生成
        public string CartId { get; set; }
        public int AlbumId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Album Album { get; set; }
    }
}