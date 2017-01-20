using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicStore.EntityFrame
{
    /// <summary>
    /// 实体框架上下文
    /// 单例模式
    /// 2017/1/20 fhr
    /// </summary>
    public class MyContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Album> Albums { get; set; }

        //构造方法中配置连接
        private MyContext()
            : base("DefaultConnection")
        {

        }
        //单例操作
        private static MyContext _context;
        public static MyContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new MyContext();
                }
                return _context;
            }
        }
    }
}