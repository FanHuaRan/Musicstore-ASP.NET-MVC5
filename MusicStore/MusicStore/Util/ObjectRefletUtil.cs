using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace MusicStore.Util
{
    /// <summary>
    /// 反射处理 
    /// 2016/12/31 fhr
    /// </summary>
    class ObjectRefletUtil
    {
        /// <summary>
        /// 反射处理 赋值
        /// </summary>
        /// <param name="newObj"></param>
        /// <param name="srcObj"></param>
        public static void SetValue<T>(T newObj, T srcObj)
        {
            var t1s = srcObj.GetType().GetProperties();
            var t2s = newObj.GetType().GetProperties();
            foreach (var p in t1s)
            {
                foreach (var q in t2s)
                {
                    if (q.Name == p.Name)
                    {// 这里有可能需要对属性的类型和值做一些判断和转换，
                        //大家自己根据自己的业务添加处理，估计不会很多  
                        q.SetValue(newObj, p.GetValue(srcObj), null);
                    }
                }
            }
        }
        /// <summary>
        /// 获取主键值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object GetMainKeyValue<T>(T obj)
        {
            PropertyInfo property = GetMainKeyProperty(typeof(T));
            return property.GetValue(obj, null);
        }
        /// <summary>
        /// 获取主键值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object GetMainKeyValue(object obj)
        {
            PropertyInfo property = GetMainKeyProperty(obj.GetType());
            return property.GetValue(obj, null);
        }
        /// <summary>
        /// 获取带主键特性的属性
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static PropertyInfo GetMainKeyProperty(Type type)
        {
            var keyPropertys = type.GetProperties().Where(p => p.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Any());
            if (keyPropertys.Count() == 0)
            {
                throw new Exception(type.ToString() + "无PrimaryKeyAttribute注解属性");
            }
            PropertyInfo property = keyPropertys.First() as PropertyInfo;
            return property;
        }
    }
}
