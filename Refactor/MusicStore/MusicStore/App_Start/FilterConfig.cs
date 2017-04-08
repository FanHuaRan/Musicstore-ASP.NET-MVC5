using MusicStore.Filters;
using System.Web;
using System.Web.Mvc;

namespace MusicStore
{
    /// <summary>
    /// 这里面注册全局拦截器
    /// </summary>
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //添加我们的过滤器到全局过滤器中 随后一起被注册
            filters.Add(new ActionAndResultFilterAttribute());
            filters.Add(new FilterExceptionAttribute());
        }
    }
}
