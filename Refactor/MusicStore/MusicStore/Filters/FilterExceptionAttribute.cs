using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Filters
{
    /// <summary>
    /// 异常处理拦截器+特性
    /// </summary>
    public class FilterExceptionAttribute:FilterAttribute,IExceptionFilter
    {
        private readonly ILog logger = LogManager.GetLogger("FilterExceptionAttribute");
        public void OnException(ExceptionContext filterContext)
        {
            //如果异常未处理
            if (!filterContext.ExceptionHandled)
            {
                logger.Error(string.Format("request{0} encounter{1}",
                    HttpContext.Current.Request.ApplicationPath,
                    filterContext.Exception.Message,
                    filterContext.Exception));
                filterContext.Result = new ViewResult
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary(filterContext.Exception.Message)
                };
                //标识异常处理
                filterContext.ExceptionHandled = true;
            }
        }
    }
}