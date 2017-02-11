﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicStore.Models
{
    /// <summary>
    /// 订单细节 对应一种专辑
    /// </summary>
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int AlbumId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Album Album { get; set; }
        public virtual Order Order { get; set; }
    }
}
