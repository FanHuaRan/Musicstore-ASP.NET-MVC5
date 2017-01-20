using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Util
{
    /// <summary>
    /// 用于标识主键字段的特性
    /// 2016/12/31 fhr
    /// </summary>
     [AttributeUsage(AttributeTargets.Property)]
    class PrimaryKeyAttribute:Attribute
    {

    }
}
