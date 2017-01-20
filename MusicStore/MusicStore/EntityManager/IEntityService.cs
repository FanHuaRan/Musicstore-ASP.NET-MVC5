using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.EntityManager
{
    /// <summary>
    /// 实体访问基本接口
    /// 2016/12/26 fhr
    /// </summary>
    public interface IEntityService<T>
    {
        T FindById(Int64 id);
        void Delete(T obj);
        T Insert(T obj);
        T Update(T obj);
        IList<T> FindAll();
        void DeleteById(Int64 id);
    }
}
